    static void Main(string[] args)
    {
        HtmlAgilityPack.HtmlWeb web = new HtmlWeb();
        HtmlDocument document = web.Load("http://localhost/testAgilityPack.html");
        HtmlNode contentNode = document.DocumentNode.SelectSingleNode("//div[@id='content']");
        Console.WriteLine(contentNode.WriteTo());
        Console.ReadLine();
    }
