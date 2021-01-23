    private void WebBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e){
       HtmlElementCollection inputCol = this.WebBrowser1.Document.GetElementsByTagName("input");
    foreach (HtmlElement el in inputCol)
    {if (el.GetAttribute("type").Equals("submit"))
     {
                                                el.InvokeMember("Click"); 
                                                MessageBox.Show("It worked!");
                                            }
                                        }
    }
