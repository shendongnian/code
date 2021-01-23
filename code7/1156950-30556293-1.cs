     private void YouTube(String Input)
        {
            try
            {
                webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
                webBrowser1.Navigate("https://www.youtube.com/");
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }
    void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlDocument Doc = webBrowser1.Document;
            HtmlElement Search = Doc.GetElementById("search_query");
            Search.SetAttribute("value",Input);
        }
