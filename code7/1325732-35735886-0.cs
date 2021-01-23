    public IEnumerable<TContent> DownloadContentFromUrls<TContent>(IEnumerable<string> urls)
    {
        var queue = new ConcurrentQueue<TContent>();
    
        using (var client = new HttpClient())
        {
            Task.WaitAll(urls.Select(url =>
            {
                return client.GetAsync(url).ContinueWith(response =>
                {
                    var content = JsonConvert.DeserializeObject<IEnumerable<TContent>>(response.Result.Content.ReadAsStringAsync().Result);
    
                    foreach (var c in content)
                        queue.Enqueue(c);
                });
            }).ToArray());
        }
  
  
    return queue;
