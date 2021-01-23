                var headers = doc.DocumentNode.SelectNodes("//h2");
    
                if (headers != null)
                {
                    foreach (HtmlNode item in headers)
                    {
                        Console.WriteLine(item.InnerText); //Artist
    
                        foreach (var item2 in item.NextSibling.SelectNodes("//b/i"))
                        {
                           Console.WriteLine(item2.InnerText); //Song name
                        }
                   
                    }
                }
