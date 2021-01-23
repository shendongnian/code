    class Types
    {
       IWebDriver webBrowser = null;
    
       public Types(IWebDriver wb)
       {
          this.webBrowser = wb;
       }
    
       public bool DoTypeA()
       {
           HtmlDocument doc = webBrowser.Document //working fine
       }
    }
