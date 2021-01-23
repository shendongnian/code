    private void bttExecute_Click(object sender, EventArgs e)
            {
                webBrowser1.Navigate(URL);            
            }
    
            private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
            {
                step++;
    
                switch (step)
                {
                    case 1: //Login step                    
    
                        webBrowser1.Document.GetElementById("txtUsername").InnerText = "user123";
                        
                        //This piece of code auto select the radio selection
                        HtmlElementCollection theElementCollection = webBrowser1.Document.GetElementsByTagName("input");
                        foreach (HtmlElement curElement in theElementCollection)
                        {
                            if (curElement.Id == "radio123")
                            {
                                curElement.InvokeMember("click");
    
                                break;
                            }
                        }
    
                        webBrowser1.Document.GetElementById("dropdown").SetAttribute("value", "2015"); 
                        webBrowser1.Document.GetElementById("button").InvokeMember("click");
    
                        break;
    
                    case 2: 
    
                        //Grab the source code and process further
                        string sourceCode = webBrowser1.DocumentText;
    
                        break;
    
                    case 3:
    
                        
    
                        break;
                }
    
            }
