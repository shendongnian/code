    static void Main(string[] args)
    {
        WebClient client = null;
        while (client == null)
        {
            Console.WriteLine("Trying..");
            client = CloudflareEvader.CreateBypassedWebClient("http://anilinkz.tv");
        }
        Console.WriteLine("Solved! We're clear to go");
            Console.WriteLine(client.DownloadString("http://anilinkz.tv/anime-list"));
        Console.ReadLine();
    }
