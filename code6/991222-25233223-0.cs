    HtmlNodeCollection divs = doc.DocumentNode.SelectNodes("//div[@style]");
                if (divs != null)
                {
                    foreach (HtmlNode div in divs)
                    {
                        string style = div.Attributes["style"].Value;
                        string pattern = @"max-width(.*?)(;)";
                        Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
                        string newStyle = regex.Replace(style, String.Empty);
                        div.Attributes["style"].Value = newStyle;
                    }
                }
