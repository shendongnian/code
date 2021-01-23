     using (WebClient webClient = new WebClient())
            {
                bool isSuccessful = false;
                string requestBody = BuildRequestBody();
                AddBasicAuthRequestHeaders(webClient, "myUser", "myPwd");
                try
                {
                    string responseString = webClient.UploadString(resourceUrl, requestBody);
                    JArray responseArray = JArray.Parse(responseString);
                    isSuccessful = (bool)responseArray[0]["IsSuccessful"];
                    if (isSuccessful)
                    {
                        objectId = (int)responseArray[0]["RequestedObject"]["Id"];
                    }
                }
                catch (Exception ex)
                {
                    string logMessage = string.Format("Error retrieving Id for object {0}. Exception: {1}\r\nDetails:{2}", objectName, ex.Message, ex.StackTrace);
                    Helper.Log(LogLevel.Error, logMessage);
                    throw (ex);
                }
            }
            return objectId;
