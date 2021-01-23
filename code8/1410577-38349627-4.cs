    class Types
    {
       IWebDriver webBrowser = null;
    
       public Types(IWebDriver wb)
       {
          if(wb == null)
             throw new NullReferenceException();
          this.webBrowser = wb;
       }
    
       public bool DoTypeA()
       {
           HtmlDocument doc = webBrowser.Document //working fine
       }
    }
