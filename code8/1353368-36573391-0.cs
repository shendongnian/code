    public static string postData;
        public static string responseString;
        public static async Task PostJsonRequest()
        {
            string AuthServiceUri = "myurl"; 
            HttpWebRequest spAuthReq = WebRequest.Create(AuthServiceUri) as HttpWebRequest;
            spAuthReq.ContentType = "application/json";
            spAuthReq.Method = "POST";
            spAuthReq.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), spAuthReq);
        }
        public static void GetRequestStreamCallback(IAsyncResult callbackResult)
        {
            HttpWebRequest myRequest = (HttpWebRequest)callbackResult.AsyncState;
            Stream postStream = myRequest.EndGetRequestStream(callbackResult);
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);
            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Dispose();
            myRequest.BeginGetResponse(new AsyncCallback(GetResponsetStreamCallback), myRequest);
        }
        public static void GetResponsetStreamCallback(IAsyncResult callbackResult)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
                HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult);
                
                Stream streamResponse = response.GetResponseStream();
                StreamReader reader = new StreamReader(streamResponse);
                responseString = reader.ReadToEnd();
                streamResponse.Dispose();
                reader.Dispose();
                response.Dispose();
            }
            catch (Exception e)
            {
                
            }
        }
        public static void EnterLoginValues(string user, string pwd)
        {
            LoginData data = new LoginData
            {
                userid = user,
                password = pwd
            };
            postData = JsonConvert.SerializeObject(data);
        }
