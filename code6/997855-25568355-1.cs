    HttpWebRequest httpWebRequest = HttpWebRequest.Create(...)
    httpWebRequest.Method = "POST";
             httpWebRequest.Headers["Authorization"] = "Basic " + ...;
             httpWebRequest.PreAuthenticate = true;
             httpWebRequest.AllowWriteStreamBuffering = false;
             httpWebRequest.AllowReadStreamBuffering = false;
             httpWebRequest.ContentType = "application/octet-stream";
             Stream st = httpWebRequest.GetRequestStream();
    st.Write(b, 0, b.Length);
    st.Write(b, 0, b.Length);
    //...
             Task<WebResponse> response = httpWebRequest.GetResponseAsync();
    
             var x = response.Result;
             Stream resultStream = x.GetResponseStream();
    //... read result-stream ...
