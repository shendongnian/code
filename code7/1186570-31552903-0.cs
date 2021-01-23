    private void iCloudLogin() {        
    string data = "{\"apple_id\":" + appleId + ", \"password\":" + password + ", \"extended_login\":false}";
            byte[] dataStream = Encoding.UTF8.GetBytes(data);
            WebRequest webRequest = WebRequest.Create(url);
            webRequest.Method = "POST";
            webRequest.Headers.Set("Origin", "https://www.icloud.com");
            webRequest.ContentLength = dataStream.Length;
            Stream newStream=webRequest.GetRequestStream();
            // Attach the data.
            newStream.Write(dataStream,0,dataStream.Length);
            newStream.Close();
            WebResponse webResponse = webRequest.GetResponse();
           //// get contact server url, dsid, Cookie
    }
