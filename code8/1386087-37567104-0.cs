    private string _username {get; set;} = ConfigurationManager.AppSettings["username"];
    private string _password {get; set;} = ConfigurationManager.AppSettings["password"];
--------------------
       var credentials = new NetworkCredential(_username, _password);
        
       var transportWeb = new Web(credentials);
    
       transportWeb.DeliverAsync(sendGridMessage);
