    public async Task TestTasksProperly()
    {
        var urls = new List<string>();
        urls.AddRange(createUrls());
        var stopwatch = Stopwatch.StartNew();
        ConcurrentQueue<string> contents = new ConcurrentQueue<string>();
        await Task.WhenAll(urls.Select(url => QueryUrl(url, contents)));
        var time = stopwatch.ElapsedMilliseconds / 1000.0;
        Console.WriteLine("Time spent in Tasks : " + time);
        Console.WriteLine("Queue size : " + contents.Count);
    }
    private static async Task QueryUrl(string url, ConcurrentQueue<string> contents)
    {
        using (var client = new HttpClient {Timeout = TimeSpan.FromSeconds(10)})
        {
            using (var response = await client.GetAsync(url).ConfigureAwait(false))
            {
                try
                {
                    var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    contents.Enqueue(content);
                }
                catch (Exception e)
                {
                }
            }
        }
    }
