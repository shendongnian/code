        private static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            string page = webClient.DownloadString("http://www.deu.edu.tr/DEUWeb/Guncel/v2_index_cron.html");
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(page);
            HtmlNode table = doc.DocumentNode.SelectSingleNode("//table");
            var rows = table.SelectNodes("//tr/td").Select(cell => cell.InnerText).Where(someVariable => !String.IsNullOrWhiteSpace(someVariable)).ToList();
        }
