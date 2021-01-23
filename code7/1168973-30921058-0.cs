    await Task.WhenAll(services.Select(async s => {
       Console.WriteLine("Running " + s.Name);
       var _serviceResponse = await client.PostAsync(...);
       Console.WriteLine(s.Name + " responded with " + _serviceResponse.StatusCode);
    }));
