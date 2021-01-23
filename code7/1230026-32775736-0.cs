            string url = "http://192.168.1.86:8080/spectrum/restful/models";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Credentials = CredentialCache.DefaultCredentials;
            string authInfo = userName + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            request.Headers["Authorization"] = "Basic " + authInfo;
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                HttpStatusCode errorCode = response.StatusCode;
                reader.Close();
                dataStream.Close();
                response.Close();
                res = responseFromServer;
            }
            catch (Exception ex)
            {
                if (response == null && ex.Message.Contains("400"))
                    res = "NoSuchUser";
                else
                    res = ex.Message;
            }
