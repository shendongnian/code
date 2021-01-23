    var req = WebRequest.CreateHttp("http://httpbin.org/get");
    
    /*
     * execute
     */
    try
    {
        using (var resp = await req.GetResponseAsync())
        {
            using (var s = resp.GetResponseStream())
            using (var sr = new StreamReader(s))
            using (var j = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                //do some deserializing http://www.newtonsoft.com/json/help/html/Performance.htm
            }
        }
    }
    catch (WebException ex)
    {
        using (HttpWebResponse response = (HttpWebResponse)ex.Response)
        {
            using (StreamReader sr = new StreamReader(response.GetResponseStream()))
            {
                string respStr = sr.ReadToEnd();
                int statusCode = (int)response.StatusCode;
    
                //do your status code logic here
            }
        }
    }
