    HttpWebRequest webRequest = WebRequest.Create("http://localhost:51467/api/email/send") as HttpWebRequest;
    webRequest.Method = "POST";
    webRequest.Credentials = CredentialCache.DefaultCredentials; //or account you wish to connect as
    webRequest.PreAuthenticate = true;
    webRequest.ContentType = "application/json"; // or xml if it's your preference
    string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(requestObject);
    using (StreamWriter streamWriter = new StreamWriter(webRequest.GetRequestStream()))
    {
        streamWriter.Write(jsonData);
        streamWriter.Flush();
        streamWriter.Close();
    }
    HttpWebResponse webResponse = webRequest.GetResponse() as HttpWebResponse;
    if (webResponse.StatusCode != HttpStatusCode.Accepted)
        throw new ApplicationException("Unexpected Response Code. - " + webResponse.StatusCode);
    string response;
    using (System.IO.StreamReader readResponse = new System.IO.StreamReader(webResponse.GetResponseStream()))
    {
        response = readResponse.ReadToEnd();
    }
    //swap out for regular xml serializer if you've used xml
    dynamic responseObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(response);
