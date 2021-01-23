    static void Main()
    {
        string content = WebClient.DownloadString("http://stackoverflow.com");
        Console.WriteLine("I'm writing something while the task is running...");
        Console.WriteLine(await content);
    }
    
