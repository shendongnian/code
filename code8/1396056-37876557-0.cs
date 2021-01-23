    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:6586/MacCommService/LoadBalanceMacValues");
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";
    
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
    {
        string json = "{ \"jsonValues\" : \"" + Uri.EscapeDataString(encryptedJson) + "\" }";
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }
    
    var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
    {
        var result = streamReader.ReadToEnd();
    }
