    private static readonly List<Task> weatherTasks = new List<Task>(); 
    
    public static void GetCurrentLocationWeatherAsync(double latitude, double longitude, Action<WeatherData> callback)
    {
    	// ...
    	weatherTasks.Add(asynClient.OpenReadTaskAsync(new Uri(url)));
    }
    
    public static void WaitForAllWeatherCalls()
    {
    	Task.WaitAll(weatherTasks.ToArray());
    	weatherTasks.Clear();
    }
