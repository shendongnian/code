    if (webBrowser1.Document != null)
                {
                    var links = webBrowser1.Document.GetElementsByTagName("a");
                    foreach (HtmlElement link in links)
                    {
                        if (link.GetAttribute("className") == "entry-title")
                        {
                            MessageBox.Show("Here");
                        }
                    }
                }
