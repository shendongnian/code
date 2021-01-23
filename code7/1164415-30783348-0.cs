    [Given(@"I set the auth header")]
    public void GivenISetTheAuthHeader()
    {
        string username = System.Configuration.ConfigurationManager.AppSettings["RestServiceUserName"];
        string password = System.Configuration.ConfigurationManager.AppSettings["RestServicePassword"];
    }
