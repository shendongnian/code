    internal class Program
    {
        private const string Url = "http://www.google.com/search?num=100&q=my+search+term";
        private static void Main(string[] args)
        {
            var result = new HtmlWeb().Load(Url);
            var nodes = result.DocumentNode.SelectNodes("//html//body//div[@class='g']");
            var indexes = nodes == null
                              ? new List<int> { 0 }
                              : nodes.Select((x, i) => new { i, x.InnerHtml })
                                    .Where(x => x.InnerHtml.Contains("mytarget"))
                                    .Select(x => x.i + 1)
                                    .ToList();
            Console.WriteLine(String.Join(", ", indexes));
            Console.ReadLine();
        }
    }
