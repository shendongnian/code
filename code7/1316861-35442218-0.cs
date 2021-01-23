        var taskList = new Task<string>[masterResult.D.Count];
        for (int i = 0; i < masterResult.D.Count; i++)        //Go through all the lists we need to pull (based on master list) and create a task-list
        {
            taskList[i] = Task.Run(() =>
            {
                using (var client = new WebClient())
                {
                    return client.DownloadStringTaskAsync(new Uri(agilityApiUrl + masterResult.D[i].ReferenceIdOfCollection + "?$format=json"));
    
                }
            }
        }
    
        Task.WaitAll(taskList.Cast<Task>().ToArray());  
