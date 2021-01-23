    public static ClientContext GetContext(Uri webUri, string userName, string password)
    {
       var securePassword = new SecureString();
       foreach (var ch in password) securePassword.AppendChar(ch);
       return new ClientContext(webUri) { Credentials = new SharePointOnlineCredentials(userName, securePassword) };
    }
 
   
