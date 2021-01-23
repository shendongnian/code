    private string SendGCMNotification()
        {
            try
            {
                string message = "some test message";
                //string tickerText = "example test GCM";
                string contentTitle = "content title GCM";
                string registration_id = "cXMf6hkYIrw:APA91bGr-8y2Gy-qzNJ3zjrlf8t-4m9uDib9P0j8GW87bH5jq891-x_7P0qqItzlc_HX‌​h11Arg76lCOcjXPrU9LAgtYLwllH2ySxA0ADSfiz3qPolajjvI3d3zE6Rh77dwRqXn3NnbAm";
               string postData =
                "{ \"registration_ids\": [ \"" + registration_id + "\" ], " +
                  "\"data\": {\"contentTitle\":\"" + contentTitle + "\", " +
                             "\"message\": \"" + message + "\"}}";
    
                string GoogleAppID = "AIzaSyA2Wkdnp__rBokCmyloMFfENchJQb59tX8";
    
                WebRequest wRequest;
                wRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                wRequest.Method = "POST";
                wRequest.ContentType = " application/json;charset=UTF-8";
                wRequest.Headers.Add(string.Format("Authorization: key={0}", GoogleAppID));
    
                var bytes = Encoding.UTF8.GetBytes(postData);
                wRequest.ContentLength = bytes.Length;
    
                var stream = wRequest.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Close();
    
                var wResponse = wRequest.GetResponse();
                stream = wResponse.GetResponseStream();
                var reader = new StreamReader(stream);
                var response = reader.ReadToEnd();
    
                var httpResponse = (HttpWebResponse)wResponse;
                var status = httpResponse.StatusCode.ToString();
    
                reader.Close();
                stream.Close();
                wResponse.Close();
    
                //TODO check status
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return "sent";
        }
