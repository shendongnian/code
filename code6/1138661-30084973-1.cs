     static void Main(string[] args)
            {
                  StringBuilder sb = new StringBuilder();
            string path = new WebClient().DownloadString("https://www.google.com");
            HtmlDocument htmlDoc = new HtmlDocument();
            ////htmlDoc.LoadHtml(File.ReadAllText(path));
            htmlDoc.LoadHtml(path);
            var bodySegment = htmlDoc.DocumentNode.Descendants("body").FirstOrDefault();
            if (bodySegment != null)
            {
                foreach (var item in bodySegment.ChildNodes)
                {
                    if (item.NodeType == HtmlNodeType.Element && string.Compare(item.Name, "script", true) != 0)
                    {
                        foreach (var a in item.Descendants())
                        {
                            if (string.Compare(a.Name, "script", true) == 0 || string.Compare(a.Name, "style", true) == 0)
                            {
                                a.InnerHtml = string.Empty;
                            }
                        }
                        sb.AppendLine(item.InnerText.Trim());
                    }
                }
            }
    
                Console.WriteLine(sb.ToString());
                Console.Read();
            }
