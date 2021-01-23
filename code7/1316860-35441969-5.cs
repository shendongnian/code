    var taskList = new Task<string>[masterResult.D.Count];
    for (int i = 0; i < masterResult.D.Count; i++)        //Go through all the lists we need to pull (based on master list) and create a task-list
    {
        var client = new WebClient();
        Task<string> task = client.DownloadStringTaskAsync(new Uri(agilityApiUrl + masterResult.D[i].ReferenceIdOfCollection + "?$format=json"));
        task.ContinueWith(x => client.Dispose());
        taskList[i] = task;
    }
    Task.WaitAll(taskList.Cast<Task>().ToArray());      //Wait for all results to come back
