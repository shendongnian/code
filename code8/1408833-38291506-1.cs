    using System.Net.Http;
    var client = new HttpClient();
    var response = await GetFirstResult(
        new Func<CancellationToken, Task<HttpResponseMessage>>[] 
        {
            ct => client.GetAsync("http://microsoft123456.com", ct),
            ct => client.GetAsync("http://microsoft123456.com", ct),
            ct => client.GetAsync("http://microsoft123456.com", ct),
            ct => client.GetAsync("http://microsoft123456.com", ct),
            ct => client.GetAsync("http://microsoft123456.com", ct),
            ct => client.GetAsync("http://microsoft123456.com", ct),
            ct => client.GetAsync("http://microsoft123456.com", ct),
            ct => client.GetAsync("http://microsoft.com", ct),
            ct => client.GetAsync("http://microsoft123456.com", ct),
            ct => client.GetAsync("http://microsoft123456.com", ct),
        }, 
        rm => rm.IsSuccessStatusCode);
    Console.WriteLine($"Successful response: {response}");
