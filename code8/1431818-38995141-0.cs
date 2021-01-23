    public static async Task<string[]> SendToAllIps(string req)
    {
        var tasks = new List<Task<string>>();
    
        for (int i = 0; i < _allIps.Length; i++)
        {
            // Start task and assign the task itself to a collection.
            var task = SendRequest(new Uri(_allIps[i] + req));
            tasks.Add(task);
        }
    
        // await all the tasks.
        string[] resp = await Task.WhenAll(tasks);
        return resp;
    }
