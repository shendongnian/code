    private void AutheticateO365(string url, string password, string userName)
    {
       Context = new ClientContext(url);
       var passWord = new SecureString();
       foreach (char c in password.ToCharArray()) passWord.AppendChar(c);
       Context.Credentials = new SharePointOnlineCredentials(userName, passWord);
       var web = Context.Web;
       Context.Load(web);
       Context.ExecuteQuery();
    }
