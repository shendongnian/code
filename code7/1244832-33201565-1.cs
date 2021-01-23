    if (webBrowser1.Document != null)
                {
                    var links = webBrowser1.Document.GetElementsByTagName("h2");
                    foreach (HtmlElement link in links)
                    {
                        if (link.GetAttribute("className") == "entry-title")
                        {
                            MessageBox.Show("Here");
                        }
                    }
                }
