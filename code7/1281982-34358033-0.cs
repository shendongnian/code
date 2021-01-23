    static void Main(string[] args)
    {
        DoWork();
        Console.ReadKey();
    }
    static async void DoWork()
    {
        WebReader wReader = new WebReader();           
        await wReader.Load("http://blogs.msdn.com/b/dotnet/");
        IEnumerable<string> imageUrls = wReader.getImage();
        foreach (string url in imageUrls)
        {
            Console.WriteLine(url);
        }
    }
