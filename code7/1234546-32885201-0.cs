               var doc = new HtmlDocument();
                doc.LoadHtml(data);
                HtmlAgilityPack.HtmlNodeCollection icCont2 = doc.DocumentNode.SelectNodes(@"//ul[@class='DefaultAspxWebParcasi']//li//a");
                foreach (HtmlAgilityPack.HtmlNode item in icCont2)
                {
                    Regex trimmer = new Regex(@"\s\s+");
                    var iler = trimmer.Replace(item.InnerText, " ");
                    Console.WriteLine(iler);
                }
