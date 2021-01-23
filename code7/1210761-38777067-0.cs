    // Setting up Service parameters
    Service _splunkService = new Service(Scheme.Https, "your-api-or-ip", 8089);
    // Authenticating
    await _splunkService.LogOnAsync("username", "password");
    // Setting up parameters for the OneShot job and executing it
    var query = "your search query";
    var oneShot = new JobArgs();
    oneShot.EarliestTime = DateTime.Now.AddMinutes(-2).Date.ToString("yyyy-MM-dd") + "T" + DateTime.Now.AddMinutes(-2).TimeOfDay; //"2015-09-12T12:00:00.000-07:00";
    oneShot.LatestTime = "your latest time";
    using (var stream = await _splunkService.SearchOneShotAsync(query, 0, oneShot))
    {
        try
        {
            foreach (var result in stream)
            {
                var rawValue = Convert.ToString(result.GetValue("_raw"));
                if (rawValue != null)
                {
                    // do something.
                }
            }
        }
    }
