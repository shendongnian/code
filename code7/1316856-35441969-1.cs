    var usedClients = new List<WebClient>(); 
    var taskList = new Task<string>[masterResult.D.Count];
    for (int i = 0; i < masterResult.D.Count; i++)        //Go through all the lists we need to pull (based on master list) and create a task-list
    {
        var client = new WebClient();
        Task<string> getDownloadsTask = client.DownloadStringTaskAsync(new Uri(agilityApiUrl + masterResult.D[i].ReferenceIdOfCollection + "?$format=json"));
        taskList[i] = getDownloadsTask;
        //Must do this, since the `DownloadAsync` has not been invoked yet.
        usedClients.Add(client);
    }
    Task.WaitAll(taskList.Cast<Task>().ToArray());      //Wait for all results to come back
    //now you can dispose them.
    foreach (var client in usedClients)
        client.Dispose();
