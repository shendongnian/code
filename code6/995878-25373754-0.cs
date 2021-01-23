    public async Task<ServiceStatus> CheckServiceAsync(string serviceName)
    {
      var startTime = DateTime.Now;
      // Simulate a longer running process, by pausing for 1-3 seconds
      var random = new Random();
      var waitTime = TimeSpan.FromMilliseconds(random.Next(1000, 3000));
      await Task.Delay(waitTime);
      var elapsedTime = (DateTime.Now - startTime).TotalSeconds;
      var service = new ServiceStatus {Name = serviceName, IsRunning = true};
      Response.Write(string.Format("Done with {0} in {1} seconds<br/>", service.Name, elapsedTime.ToString("N2")));
      Response.Flush();
      return service;
    }
