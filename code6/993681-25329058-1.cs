    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(baseurl);
    request.Method = "POST";
    request.Accept = "application/json";
    request.Credentials = new NetworkCredential(username, password);
    request.ContentType = "application/json; charset=utf-8";
    using (var streamWriter = new StreamWriter(request.GetRequestStream()))
    {
        string json = "{\"browser\":\"Win7x64-C1|Chrome32|1024x768\",\"url\":\"http://www.google.com\"}";
        streamWriter.Write(json);
    }
    var response = request.GetResponse();
    string text;
    using (var sr = new StreamReader(response.GetResponseStream()))
    {
        text = sr.ReadToEnd();
        values.Add(text);
    }
