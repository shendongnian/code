     public static class WebClientExtension
    {
        public static T DownloadSerializedJsonData<T>(string url) where T : new()
        {
            var contentType = ConfigurationManager.AppSettings["ContentType"];//content type in app config or web config
            using (var webClient = new WebClient())
            {
                webClient.Headers.Add("Content-Type", contentType);
                var jsonData = string.Empty;
                try
                {
                    jsonData = webClient.DownloadString(url);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
            }
        }
        public static T AuthorizationContentSerializedJsonData<T>(string url) where T : new()
        {
            string jsonData = null;
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                //ClientBase.AuthorizeRequest(httpRequest, Authorization.AccessToken);
                var response = httpRequest.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                var readStream = new StreamReader(receiveStream, Encoding.UTF8);
                jsonData = readStream.ReadToEnd();
                response.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return !string.IsNullOrEmpty(jsonData) ? JsonConvert.DeserializeObject<T>(jsonData) : new T();
        }
    }
