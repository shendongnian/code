    var httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:83/Ade.svc/post/address");
    httpWebRequest.ContentType = "application/json";
    httpWebRequest.Method = "POST";
    
    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                   {
                       string json = "{\"k\":\"key\"," +
                           "{\"source\":\"test test\"," +
                           "{\"isUrl\":\"0\"," +
                           "\"ISO2Code\":\"be\"}";
    
                       streamWriter.Write(json);
                       streamWriter.Flush();
                       streamWriter.Close();
                   }
    
      var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
      using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
         {
            var result = streamReader.ReadToEnd();    
         }
