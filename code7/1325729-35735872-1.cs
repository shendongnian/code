    public static async Task<int> Test()
    {
        int ret = 0;
        HttpClient client = new HttpClient();
        List<Task> taskList = new List<Task>();
        for (int i = 1000; i <= 1100; i++)
        {
            var i1 = i;
            taskList.Add(client.GetStringAsync($"https://en.wikipedia.org/wiki/{i1}"));
        }
        await Task.WhenAll(taskList.ToArray());
        return ret;
    }
