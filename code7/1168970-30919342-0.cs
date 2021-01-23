    foreach(var service in services)
    {
        Console.WriteLine("Running " + service.Name);
        var _serviceResponse = await client.PostAsync(_baseURL + service.Id.ToString(), null);
        Console.WriteLine(service.Name + " responded with " + _serviceRepsonse.StatusCode);
    }
