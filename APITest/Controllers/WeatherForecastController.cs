using Microsoft.AspNetCore.Mvc;

namespace APITest.Controllers;

[ApiController]
//[Route("[controller]")]
[Route("api/v1/weather")]
[ApiVersion("1.0")]
[ApiVersion("1.1")]
[ApiVersion("2.0")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Gets the weather forecast.
    /// </summary>
    /// <param name="id"></param>
    /// <returns>WeatherForecast</returns>
    [HttpGet(Name = "GetWeatherForecast")]
    [Produces("application/json")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}

