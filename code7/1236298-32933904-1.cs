        private void OnDocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs args)
        {
           if (args.Url == initialUrl)
            {
                HtmlElementCollection elements =
                    webBrowser.Document.Window.Frames[0].Document.GetElementsByTagName("div");
                foreach (HtmlElement element in elements)
                {
                    if (element.GetAttribute("id").Equals("SB_Content_PagePreview"))
                    {
                        element.InvokeMember("Click");
                    }
                }
            }
        }
