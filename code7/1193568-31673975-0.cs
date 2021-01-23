    static void Main(string[] args)
    {
        Console.ReadLine(worker_DoWork().Result); //intentionally blocking here
    }
    
    static async Task<string> worker_DoWork()
    {
        var client = new HttpClient();
    
        string httpResult = await client.GetStringAsync("http://ozgurakpinar.net/androidserver.aspx?param=accenture2");
        return httpResult;
    }
