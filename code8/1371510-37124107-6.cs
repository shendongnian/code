    public static List<Definitions> GetData()
    { 
        string result = "";
        List<Definitions> allDefinitions =  new List<Definitions>();
        for (int page = 1; page <= 5; page++)
        {
          for( int i = 0;i < 50;i++)
          {
            string fpage = "&page=" + page;                            
            string ApiToken = "something";
            string url = " https://someWebSite" + fpage;                          
            string userpass = ApiToken + ":api_token";
            string userpassB64 = Convert.ToBase64String(Encoding.Default.GetBytes(userpass.Trim()));
            string authHeader = "Basic " + userpassB64;
            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(url);
            authRequest.Headers.Add("Authorization", authHeader);
            authRequest.Method = "GET";
            authRequest.ContentType = "application/json";
            var response = (HttpWebResponse)authRequest.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            result = sr.ReadToEnd();
            var obj = Newtonsoft.Json.JsonConvert.DeserializeObject(result);
            var f = Newtonsoft.Json.JsonConvert.SerializeObject(obj, Newtonsoft.Json.Formatting.Indented);
            var definition = JsonConvert.DeserializeObject<Definitions>(f);
            allDefinitions.Add(definition);
          }
        }
        return allDefinitions;
     }
