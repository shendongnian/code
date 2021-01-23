    using (var client = new WebClient())
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
    
        query["model"] = Model;
        //code goes here for other parameters....
    
        string apiurl = System.Web.Configuration.WebConfigurationManager.AppSettings["ApiURL"];
        var url = new UriBuilder(apiurl);
        url.Query = HttpUtility.UrlEncode(query.ToString());
    
        string xml = client.DownloadString(url.ToString());
        XmlDocument doc = new XmlDocument();
        //code goes here ....
    
    }
