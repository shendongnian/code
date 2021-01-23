    public class MyObject
    {
        public async Task Run()
        {
            var result = await Post(someData);
            DoOtherStuff();
        }
    }
    
    static async Task<string> Post(string data)
    {
        using (var client = new HttpClient())
        {
            //Hangs here until all timers are started
            var response = await client.PostAsync(new Uri(url), new StringContent(data)).ConfigureAwait(continueOnCapturedContext: false);
            var text = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
    
            return text;
        }
    }
    
    static void Main(string[] args)
    {
        var tasks = new List<Task>();
    
        for (int i = 0; i < 1000; i++)
        {
            TimeSpan delay = TimeSpan.FromSeconds(1);
            if (i % 2 == 0) delay = TimeSpan.FromDays(1);
    
            tasks.Add(Task.Delay(delay).ContinueWith((_) => new MyObject().Run()));
        }
        
        Task.WaitAll(tasks.ToArray());
    
        Console.WriteLine("Work done");
        Console.ReadKey();
    }
