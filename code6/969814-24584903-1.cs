    // Simple POST request
    using (System.Net.WebClient wb = new System.Net.WebClient())
    {
        // Random user data API - http://randomuser.me/
        string url = "http://api.randomuser.me/";
    
        var data = new System.Collections.Specialized.NameValueCollection();
        var responseStringJson = Encoding.Default.GetString(wb.UploadValues(url, "POST", data));
    
        var jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        var results = jsSerializer.Deserialize<RootObject>(responseStringJson);
    
        Console.WriteLine(results.results[0].version);
        Console.WriteLine(results.results[0].user.name.first);
        Console.ReadLine();
    }
