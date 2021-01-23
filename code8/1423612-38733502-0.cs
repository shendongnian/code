    foreach (HtmlNode node in doc.SelectNodes("//*[@class='info']//a"))
                    {
                        string value = node.InnerText;
                        Console.WriteLine(value);
                    }
