      public class NotificationManager
        {
            private readonly string AppId;
            private readonly string SenderId;
    
            public NotificationManager(string appId, string senderId)
            {
                AppId = appId;
                SenderId = senderId;
                //
                // TODO: Add constructor logic here
                //
            }
    
            public void SendNotification(List<string> deviceRegIds, string message, string title, long id)
            {
                var skip = 0;
                const int batchSize = 1000;
                while (skip < deviceRegIds.Count)
                {
                    try
                    {
                        var regIds = string.Join("\",\"", deviceRegIds.Skip(skip).Take(batchSize));
    
                        skip += batchSize;
    
                        var nm = new NotificationMessage
                        {
                            Title = title,
                            Message = message,
                            ItemId = id
                        };
    
                        var value = JsonConvert.SerializeObject(nm);
                        WebRequest wRequest;
                        wRequest = WebRequest.Create("https://android.googleapis.com/gcm/send");
                        wRequest.Method = "POST";
                        wRequest.ContentType = " application/json;charset=UTF-8";
                        wRequest.Headers.Add(string.Format("Authorization: key={0}", AppId));
                        wRequest.Headers.Add(string.Format("Sender: id={0}", SenderId));
    
                        var postData =
                            "{\"collapse_key\":\"score_update\",\"time_to_live\":108,\"delay_while_idle\":true,\"data\": { \"message\" : " +
                            "\"" + value + "\",\"time\": " + "\"" + DateTime.Now +
                            "\"},\"registration_ids\":[\"" + regIds + "\"]}";
    
                        var bytes = Encoding.UTF8.GetBytes(postData);
                        wRequest.ContentLength = bytes.Length;
    
                        var stream = wRequest.GetRequestStream();
                        stream.Write(bytes, 0, bytes.Length);
                        stream.Close();
    
                        var wResponse = wRequest.GetResponse();
    
                        stream = wResponse.GetResponseStream();
    
                        var reader = new StreamReader(stream);
    
                        var response = reader.ReadToEnd();
    
                        var httpResponse = (HttpWebResponse) wResponse;
                        var status = httpResponse.StatusCode.ToString();
    
                        reader.Close();
                        stream.Close();
                        wResponse.Close();
    
                        //TODO check status
                    }
                    catch
                    {
                        //TODO Handle exception
                    }
                }
            }
    
            private class NotificationMessage
            {
                public long ItemId;
                public string Message;
                public string Title;
            }
        }
