        static void Main(string[] args)
        {
            string html = "<span>This is an <b>Example</b> of the string</span>";
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            List<HtmlNode> spanNodes = doc.DocumentNode.Descendants().Where(x => x.Name == "span").ToList();
            foreach (HtmlNode node in spanNodes)
            {
                HtmlNode boldNode = node.SelectSingleNode("b");
                node.RemoveChild(boldNode, true);
            }
            Console.WriteLine(doc.DocumentNode.OuterHtml);
        }
