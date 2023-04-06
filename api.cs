using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Enter a city name: ");
        string city = Console.ReadLine();

        // Replace "YOUR_API_KEY" with your actual API key
        string apiKey = "YOUR_API_KEY";
        string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}";

        using var client = new HttpClient();
        var response = await client.GetAsync(apiUrl);
        var content = await response.Content.ReadAsStringAsync();

        if (response.IsSuccessStatusCode)
        {
            var weatherData = JsonSerializer.Deserialize<WeatherData>(content);
            Console.WriteLine($"Temperature in {city}: {weatherData.Main.Temp}°F");
        }
        else
        {
            Console.WriteLine($"Error: {response.StatusCode}");
        }
    }

    class WeatherData
    {
        public MainData Main { get; set; }
    }

    class MainData
    {
        public double Temp { get; set; }
    }
}
