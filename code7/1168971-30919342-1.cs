    var serviceCallTaskList = new List<Task<HttpResponseMessage>>();
    foreach(var service in services)
    {
        Console.WriteLine("Running " + service.Name);
        serviceCallTaskList.Add(client.PostAsync(_baseURL + service.Id.ToString(), null));
    }
    
    HttpResponseMessage[] responseArray = await Task.WhenAll(serviceCallTaskList);
    
    for(int i = 0; i < responseArray.Length; i++)
    {
        Console.WriteLine(services[i].Name + " responded with " + responseArray[i].StatusCode);
    }
