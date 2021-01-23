    public void PostData(string data, Action<string> callback)
    {
        var client = new HttpClient();
        var task = client.PostAsync("uri", new StringContent(data));
        task.ContinueWith((t) =>
        {
            t.Result.Content.ReadAsStringAsync().ContinueWith((trep) =>
            {
                string response = trep.Result;
                callback(response);
            });
        });
    }
