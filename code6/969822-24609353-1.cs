    class ServiceConnection
        {
            public string url = "";
            private string postXml;
            public delegate void OnServerEndResponse(string response, int statusCode);
            public event OnServerEndResponse OnEndResponse;
    
            public ServiceConnection()
            {
                url = "http://www.webservicex.net/CurrencyConvertor.asmx";
            }
    
            public void ServiceCall(string pxml)
            {
                postXml = pxml;
                WebRequest request = WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/xml;charset=UTF-8";
                request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
            }
    
            void GetRequestStreamCallback(IAsyncResult asynchronousResult)
            {
                HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                Stream postStream = webRequest.EndGetRequestStream(asynchronousResult);
                string postData = postXml;
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                postStream.Write(byteArray, 0, byteArray.Length);
                postStream.Close();
                webRequest.BeginGetResponse(new AsyncCallback(GetResponseCallback), webRequest);
            }
    
            void GetResponseCallback(IAsyncResult asynchronousResult)
            {
                try
                {
                    HttpWebRequest webRequest = (HttpWebRequest)asynchronousResult.AsyncState;
                    HttpWebResponse response;
                    response = (HttpWebResponse)webRequest.EndGetResponse(asynchronousResult);
                    Stream streamResponse = response.GetResponseStream();
                    StreamReader streamReader = new StreamReader(streamResponse);
                    string Response = streamReader.ReadToEnd();
                    streamResponse.Close();
                    streamReader.Close();
                    response.Close();
                    Deployment.Current.Dispatcher.BeginInvoke(() =>
                    {
                        OnEndResponse(Response, Convert.ToInt32(response.StatusCode));
                    });
                   
                }
                catch
                {
                    OnEndResponse("", 500);
                }
            }
