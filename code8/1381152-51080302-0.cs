     public  SendNotice(int deviceType, string deviceToken, string message, int badge, int status, string sound)
        {
            AndroidFCMPushNotificationStatus result = new AndroidFCMPushNotificationStatus();
            try
            {
                result.Successful = false;
                result.Error = null;
                var value = message;
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                tRequest.ContentType = "application/json";
                var serializer = new JavaScriptSerializer();
                var json = "";
                tRequest.Headers.Add(string.Format("Authorization: key={0}", "AA******"));
                tRequest.Headers.Add(string.Format("Sender: id={0}", "11********"));
               if (DeviceType == 2)
                {
                    var body = new
                      {
                          to = deviceToken,
                          data = new
                          {
                              custom_notification = new
                                {
                                    title = "Notification",
                                    body = message,
                                    sound = "default",
                                    priority = "high",
                                    show_in_foreground = true,
                                    targetScreen = notificationType,//"detail",
                                                                    },
                          },
                          priority = 10
                      };
                    json = serializer.Serialize(body);
                }
                else
                {
                    var body = new
                    {
                        to = deviceToken,
                        content_available = true,
                        notification = new
                        {
                            title = "Notification",
                            body = message,
                            sound = "default",
                            show_in_foreground = true,
                        },
                        data = new
                        {
                            targetScreen = notificationType,
                            id = 0,
                        },
                        priority = 10
                    };
                    json = serializer.Serialize(body);
                }
                Byte[] byteArray = Encoding.UTF8.GetBytes(json);
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
	}
        
        
