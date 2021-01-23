    public void PostData(string data, Action<string> callback)
    {
        var client = new HttpClient();
        var task = client.PostAsync("uri", new StringContent(data));
        Task.Factory.StartNew(() =>
        {
            task.Wait();
            callback(task.Result.Content.ReadAsStringAsync().Result);
        });
    }
