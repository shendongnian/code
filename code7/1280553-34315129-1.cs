    static void Main(string[] args)
    {
        var cts = new CancellationTokenSource();
    
        System.Console.CancelKeyPress += (s, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
        };
    
        MainAsync(args, cts.Token).Wait();
    }
    
    static async Task MainAsync(string[] args, CancellationToken token)
    {
        string baseAddress = "http://localhost:13204/DateTime";
    
        using (var httpClient = new HttpClient())
        {
            string response = await httpClient.GetStringAsync(baseAddress);
        }
    }
