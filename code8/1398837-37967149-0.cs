    using (client = new MyWebService())
    {
        var username = ConfigurationManager.AppSettings["WSUserName"]
        var password = ConfigurationManager.AppSettings["WSPassword"]
        client.Credentials = new NetworkCredential(username, password);
        // .. and the call here ..
    }
