    WebRequest tRequest = WebRequest.Create(fcmAPIServerURL);
                            tRequest.Method = "post";
                            tRequest.ContentType = "application/json";
                            var objNotification = new
                            {
                                to = notification.DeviceToken,
                                data = new
                                {
                                    title = notification.NotificationTitle,
                                    body = notification.NotificationBody
                                }
                            };
                            string jsonNotificationFormat = Newtonsoft.Json.JsonConvert.SerializeObject(objNotification);
                            Byte[] byteArray = Encoding.UTF8.GetBytes(jsonNotificationFormat);
                            tRequest.Headers.Add(string.Format("Authorization: key={0}", apiKey));
                            tRequest.Headers.Add(string.Format("Sender: id={0}", project_number));
                            tRequest.ContentLength = byteArray.Length;
                            tRequest.ContentType = "application/json";
                            using (Stream dataStream = tRequest.GetRequestStream())
                            {
                                dataStream.Write(byteArray, 0, byteArray.Length);
                                using (WebResponse tResponse = tRequest.GetResponse())
                                {
                                    using (Stream dataStreamResponse = tResponse.GetResponseStream())
                                    {
                                        using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                        {
                                            String responseFromFirebaseServer = tReader.ReadToEnd();
                                            FCMResponse response = Newtonsoft.Json.JsonConvert.DeserializeObject<FCMResponse>(responseFromFirebaseServer);
                                            if (response.success == 1)
                                            {
                                                new NotificationBLL().InsertNotificationLog(dayNumber, notification, true);
                                            }
                                            else if (response.failure == 1)
                                            {
                                                new NotificationBLL().InsertNotificationLog(dayNumber, notification, false);
                                                sbLogger.AppendLine(string.Format("Error sent from FCM server, after sending request : {0} , for following device info: {1}", responseFromFirebaseServer, jsonNotificationFormat));
                                            }
                                        }
                                    }
                                }
                            }
