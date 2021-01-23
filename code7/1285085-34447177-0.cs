    HtmlElementCollection elc = this.WebBrowserWindow.Document.GetElementsByTagName("button");
                foreach (HtmlElement el in elc)
                {
                    if (el.GetAttribute("type").Equals("submit"))
                    {
                        el.InvokeMember("Click");
                        break;
                    }
                }
