    public void BrowserLogin(string username, string password)
    {
    ...
    }
    
    public void BrowserLogin(string username)
    {
      BrowserLogin(username, _password);
    }
    
    public void BrowserLogin()
    {
      BrowserLogin(_username, _password);
    }
