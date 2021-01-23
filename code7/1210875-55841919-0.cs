    using (var client = new HttpClient())
    {    
      string relativeURL = "api/blah";
      //These three lines - BaseAddress, DefaultRequestHeaders and DefaultRequestHeaders
      client.BaseAddress = new Uri(Constants.ServiceBaseAddress);
      client.DefaultRequestHeaders.Clear();
      client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      HttpResponseMessage response = await client.GetAsync(relativeURL);
      ...
    }
