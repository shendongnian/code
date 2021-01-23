        var headers = doc.DocumentNode.SelectNodes("//h2");
        if (headers != null)
        {
            foreach (HtmlNode item in headers)
            {
                Console.WriteLine(item.InnerText);
                var next = item.NextSibling;
                while (next != null)
                {
                    if (next.FirstChild != null && next.FirstChild.Name == "i")
                    {
                        Console.WriteLine(next.InnerText);
                    }
                    if (next.Name == "h2")
                    {
                        break;
                    }
                    next = next.NextSibling;
                }
            }
        }
