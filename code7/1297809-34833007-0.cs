                //request url twice
                pageLoaded = false;
                string url = "https://someurl.com" ;
                webBrowser1.DocumentCompleted += browser_DocumentCompleted;
                webBrowser1.Navigate(url);
                while (pageLoaded == false)
                {
                    Thread.Sleep(500);       
                    Application.DoEvents();  
                }
              
                
                pageLoaded = false;
                url = "https://someurl.com";
                webBrowser1.DocumentCompleted += browser_DocumentCompleted;
                webBrowser1.Navigate(url);
                while (pageLoaded == false)
                {
                    Thread.Sleep(500);       
                    Application.DoEvents();  
                }
    
                result = (webBrowser1.Document.GetElementById("someid"));
                value = result.InnerText;
            void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                pageLoaded = true;
            }
