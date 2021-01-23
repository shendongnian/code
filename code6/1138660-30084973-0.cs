     static void Main(string[] args)
            {
                StringBuilder sb = new StringBuilder();
                string path = "F:\\test.html";
                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.LoadHtml(File.ReadAllText(path));
                var bodySegment = htmlDoc.DocumentNode.Descendants("body").FirstOrDefault();
                if (bodySegment != null)
                {
                foreach (var item in bodySegment.ChildNodes)
                {
                    if (item.NodeType == HtmlNodeType.Element)
                    {
                        sb.AppendLine(item.InnerText.Trim());
                    }
                }
                }
    
                Console.WriteLine(sb.ToString());
                Console.Read();
            }
