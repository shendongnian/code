    protected async Task CheckServicesAsync()
    {
      Response.Write(string.Format("Starting checks at {0}<br/>", DateTime.Now.ToLongTimeString()));
      var tasks = new List<Task<ServiceStatus>>
      {
        CheckService("ServiceOne"),
        CheckService("ServiceTwo"),
        CheckService("ServiceThree")
      };
      var checkResults = (await Task.WhenAll(tasks)).ToList();
      Response.Write(string.Format("Checking complete at {0}<br/>", DateTime.Now.ToLongTimeString()));
      Response.Flush();
    }
