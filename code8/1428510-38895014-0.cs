    using Newtonsoft.JSON;
    
    //your login info
    LoginInfo li = new LoginInfo(){AdminNo ="John Doe",Password="123456"};
    
    // your response string
    string response= await GetStreamAsync("url",li,null);
    
    private async Task<string> GetStreamAsync(string url, object body, Dictionary<string, string> headers)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
         request.Accept = "application/json";
        request.ContentType = "application/json";
        request.Method = "POST";
        if (headers != null)
            foreach (var kv in headers)
                request.Headers[kv.Key] = kv.Value;
        var stream = await request.GetRequestStreamAsync();
        
        using (var writer = new StreamWriter(stream))
        {
            if (body != null)
                writer.Write(JsonConvert.SerializeObject(body));
            writer.Flush();
            writer.Dispose();
        }
        
        var response = await request.GetResponseAsync();
        var respStream = response.GetResponseStream();
        using (StreamReader sr = new StreamReader(respStream))
        {
            return sr.ReadToEnd();
        }
    }
    
    public class LoginInfo
    {
        public string AdminNo{get;set;}
        public string Password{get;set;}
    }
