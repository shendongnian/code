            static string PathToSvgFile;
            public static void OpenSVG(this WebBrowser webBrowser, string pathToSvgFile)
            {
                if (webBrowser.ReadyState == WebBrowserReadyState.Complete || webBrowser.ReadyState == WebBrowserReadyState.Uninitialized)
                {
                    webBrowser.Navigate([Path to emptyPage.html]);
                    PathToSvgFile = pathToSvgFile;
                    webBrowser.Navigated += webBrowser_Navigated;
                } 
            }
        
            private static void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
            {
                var webBrowser = ((WebBrowser)sender);
                HtmlElementCollection head = webBrowser.Document.GetElementsByTagName("head");
        
                if (head != null)
                {
                    var element = webBrowser.Document.CreateElement("script");
                    element.SetAttribute("type", "text/javascript");
                    var elementDom = (MSHTML.IHTMLScriptElement)element.DomElement;
                    elementDom.src = [JavaScriptFile.js];
                    ((HtmlElement)head[0]).AppendChild(element);
                }
        
                webBrowser.Document.Body.InnerHtml = String.Format(webBrowser.Document.Body.InnerHtml, PathToSvgFile);
                webBrowser.Navigated -= webBrowser_Navigated; 
            }
    
