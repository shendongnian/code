    [TestMethod]
    public void VerifyAppSettingsAreRead()
    {
        string port = System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpPort"];
        string host = System.Web.Configuration.WebConfigurationManager.AppSettings["SmtpHost"];
    
       Assert.IsTrue(!String.IsNullOrEmpty(port) && !String.IsNullOrEmpty(host));
    }
