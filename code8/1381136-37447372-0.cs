    public AndroidFCMPushNotificationStatus SendNotification(string serverApiKey, string senderId, string deviceId, string message)
    {
        AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
        try
        {
            result.Successful = false;
            result.Error = null;
            var value = message;
            WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
            tRequest.Method = "post";
            tRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            tRequest.Headers.Add(string.Format("Authorization: key={0}", serverApiKey));
            tRequest.Headers.Add(string.Format("Sender: id={0}", senderId));
            string postData = "collapse_key=score_update&time_to_live=108&delay_while_idle=1&data.message=" + value + "&data.time=" + System.DateTime.Now.ToString() + "&registration_id=" + deviceId + "";
            Byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            tRequest.ContentLength = byteArray.Length;
            using (Stream dataStream = tRequest.GetRequestStream())
            {
                dataStream.Write(byteArray, 0, byteArray.Length);
                using (WebResponse tResponse = tRequest.GetResponse())
                {
                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                    {
                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                        {
                            String sResponseFromServer = tReader.ReadToEnd();
                            result.Response = sResponseFromServer;
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            result.Successful = false;
            result.Response = null;
            result.Error = ex;
        }
        return result;
    }
    public class AndroidFCMPushNotificationStatus
    {
        public bool Successful
        {
            get;
            set;
        }
        public string Response
        {
            get;
            set;
        }
        public Exception Error
        {
            get;
            set;
        }
    }
