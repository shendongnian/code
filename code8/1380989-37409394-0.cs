            string s = "<title>Google Adwords&amp;trade;</title>";
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(s);
            var titleNode = doc.DocumentNode.SelectSingleNode("//title");
            //prints Google Adwords&amp;trade;
            Console.WriteLine(titleNode.InnerText);
            //prints Google Adwords&trade;
            Console.WriteLine(HttpUtility.HtmlDecode(titleNode.InnerText));
