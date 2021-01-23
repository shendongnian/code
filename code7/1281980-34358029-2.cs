    static void Main(string[] args)
    {
         WebReader wReader = new WebReader();           
        wReader.Load("http://blogs.msdn.com/b/dotnet/")).Wait();
        IEnumerable<string> imageUrls = wReader.getImage();
        foreach (string url in imageUrls)
        {
            Console.WriteLine(url);
        }
    }
