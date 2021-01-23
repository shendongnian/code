    var address = await GetAddressAsync(apiPath); 
    // address is like: http://api.meetup.com/{groupID}/events?sign=true&key={API key}
    
    var json = "{name: \"Tenshiko's Test Event\"}"; 
    var encoding = new ASCIIEncoding ();
    var byte1 = encoding.GetBytes(json);
    var request = WebRequest.Create(address);
    request.Method = "POST";
    request.ContentType = "application/json";
    request.ContentLength = byte1.Length;
    
    using (var reqstream = new request.GetRequestStream())
    {
        reqstream.Write(byte1, 0, byte1.Length);
    }
    
    try
    {
        WebResponse response = await request.GetResponseAsync();
    
        var dataStream = response.GetResponseStream();
        StreamReader reader = new StreamReader(dataStream);
        string responseString = reader.ReadToEnd();
    
        var model = JsonConvert.DeserializeObject<TResponse>(responseString);
    
        reader.Close();
        dataStream.Close();
        response.Close();
    
        return model;
    }
    catch (WebException e)
    {
        using (WebResponse response = e.Response)
        {
            HttpWebResponse httpResponse = (HttpWebResponse)response;
    
            using (Stream data = response.GetResponseStream())
            using (var reader = new StreamReader(data))
            {
                string text = reader.ReadToEnd();
            }
        }
    }
