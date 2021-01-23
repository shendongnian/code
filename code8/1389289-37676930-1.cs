    using Newtonsoft.Json;
    public static void SaveOrUpdateEntity(string url, object data)
    {    
        var dataString = JsonConvert.SerializeObject(data);
        
        using (var client = new WebClient())
        {
            client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
        	response = client.UploadString(new Uri(rootUrl), "POST", dataString);
        }
    }
