    class WeatherGatherer
    {
    	private readonly List<Task> weatherTasks = new List<Task>();
    
    	public void GetCurrentLocationWeatherAsync(double latitude, double longitude, Action<WeatherData> callback)
    	{
    		// ...
    		weatherTasks.Add(asynClient.OpenReadTaskAsync(new Uri(url)));
    	}
    
    	public void WaitForAllWeatherCalls()
    	{
    		Task.WaitAll(weatherTasks.ToArray());
    		weatherTasks.Clear();
    	}
    }
