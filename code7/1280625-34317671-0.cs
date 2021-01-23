    using Newtonsoft.Json; // at the top of your file
    static void Main(string[] args)
    {
        var cts = new CancellationTokenSource();
        MainAsync(args, cts.Token).Wait();
    }
    static async Task MainAsync(string[] args, CancellationToken token)
    {
        string baseAddress = "http://localhost:18207/api/values/GetMyClass";
        using (var httpClient = new HttpClient())
        {
            string json = await httpClient.GetStringAsync(baseAddress);
            MyClass instance = JsonConvert.DeserializeObject<MyClass>(json);
        }
    }
