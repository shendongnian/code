    bool clicked = false;
            private void webBrowser2_DocumentCompleted_1(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
    
                if (this.webBrowser2.Document != null)
                {
                    if (clicked == false)
                    {
                        HtmlElementCollection items = webBrowser2.Document.GetElementsByTagName("span");
                        foreach (HtmlElement item in items)
                        {
                            if (item.GetAttribute("className") == "addMessage")
                            {
                                item.InvokeMember("click");
                                clicked = true;
                                break;
                            }
                        }
                    }
                }
            }
