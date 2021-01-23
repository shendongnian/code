    static void Main(string[] args)
    {
        // it's okay here to use wait because we're at the root of the application
        new AsyncServerCalls().MainAsyncCall().Wait();
        Console.ReadKey();
    }
    public class AsyncServerCalls
    {
    // dont use static async methods
    public async Task MainAsyncCall()
    {
        ServicePointManager.DefaultConnectionLimit = 999999;
        List<Task> allPages = new List<Task>();
        for (int i = 0; i <= 10; i++)
        {
            var page = i;
            allPages.Add(processPage(page));
        }
        await Task.WhenAll(allPages.ToArray());
        Console.WriteLine("Finished all pages");
    }
    public static async Task processPage(Int32 page)
    {
        List<Task> players = new List<Task>();
        using (var client = new HttpClient())
        {
            string url = "<Request URL>";
            var response = await client.GetAsync(url)// nope .Result;
            var content = await response.Content.ReadAsStringAsync(); // again never use .Result;
            dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
            dynamic data = item.data;
            var localPage = page;
            Console.WriteLine($"Processing Page: {localPage}");
            foreach (dynamic d in data)
            {
                players.Add(processPlayer(d, localPage)); // no need to put the task unnecessarily on a different thread, let the current SynchronisationContext deal with that
            }
        }
        await Task.WhenAll(players.ToArray()); // always await a task in an async method
        Console.WriteLine($"Finished Page: {page}");
    }
    public static async Task processPlayer(dynamic player, int page)
    {
        using (var client = new HttpClient())
        {
            string url = "<Request URL>";
            HttpResponseMessage response = null;
            response = await client.GetAsync(url); // don't use .Result;
            var content = await response.Content.ReadAsStringAsync();
            dynamic item = Newtonsoft.Json.JsonConvert.DeserializeObject(content);
            Console.WriteLine($"{page}: Processed {item.name}");
        }
    }
    }
