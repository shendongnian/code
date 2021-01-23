        var headers = doc.DocumentNode.SelectNodes("//h2");
        if (headers != null)
        {
            foreach (HtmlNode item in headers)
            {
                Console.WriteLine(item.InnerText); //Artist Name
                var next = item.NextSibling;
                while (next != null)
                {
                    if (next.FirstChild != null && next.FirstChild.Name == "i")
                    {
                        Console.WriteLine(next.InnerText); //Song Name for artist
                    }
                    if (next.Name == "h2")
                    {
                        break;
                    }
                    next = next.NextSibling;
                }
            }
        }
