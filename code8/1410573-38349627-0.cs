    class Types
    {
       System.Windows.Forms.WebBrowser webBrowser = null;
    
       public DownloadTypes(WebBrowser wb)
       {
          this.webBrowser = wb;
       }
    
       public bool DoTypeA()
       {
           HtmlDocument doc = webBrowser.Document //working fine
       }
    }
