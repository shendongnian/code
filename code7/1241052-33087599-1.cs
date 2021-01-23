     using (WebClient client = new WebClient())
     {
         client.Headers[HttpRequestHeader.ContentType] = "application/json";
         var jsonObj = JsonConvert.SerializeObject(yourArray); //yourArray is a device[]
         client.UploadString(ApiServiceUrl, jsonObj);
     }
