    public static string ExcutePushNotification(string title, string msg, string fcmToken, object data) 
    {
            var serverKey = "AAAA*******************";
            var senderId = "3333333333333";
        
        
            var result = "-1";
            
            var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers.Add(string.Format("Authorization: key={0}", serverKey));
            httpWebRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            httpWebRequest.Method = "POST";
        
            
            var payload = new
            {
                notification = new
                {
                    title = title,
                    body = msg,
                    sound = "default"
                },
                
                data = new
                {
                    info = data
                },
                to = fcmToken,
                priority = "high",
                content_available = true,
        
            };
        
        
            var serializer = new JavaScriptSerializer();
            
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = serializer.Serialize(payload);
                streamWriter.Write(json);
                streamWriter.Flush();
            }
        
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                result = streamReader.ReadToEnd();
            }
            return result;
    }
