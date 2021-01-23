    public HttpResponseMessage Get(string system)
    {
        
      string domain = new System.DirectoryServices.AccountManagement.PrincipalContext(ContextType.Domain).ConnectedServer; 
      return new HttpResponseMessage()  {   Content = new StringContent(domain )   };
    }
