        using (WebClient wc = new WebClient()) 
         {
             string url = currentURL + "resources?AUTHTOKEN=" + pmtoken;
             Uri uri = new Uri(url);       
             wc.Headers.Add(HttpRequestHeader.ContentType, "application/x-www-form-urlencoded");
        
             var encodedJson = WebUtility.UrlEncode(data);
        
             NameValueCollection myNameValueCollection = new NameValueCollection();
             myNameValueCollection.Add("INPUT_DATA",encodedJson);
             crudoutput = wc.UploadValues(uri, myNameValueCollection);
         }
