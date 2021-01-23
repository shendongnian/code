        public static void SendFile(string FileName, string MimeType, byte[] FileContent, string ClientId, string ApplicationId, string ApiKey, Action<string> OnCompleted)
        { 
            string BaseServer =   "https://api.parse.com/{0}/files/{1}";
            HttpWebRequest req = HttpWebRequest.CreateHttp(string.Format(BaseServer, ClientId, FileName));
            SetHeader(req, "X-Parse-Application-Id", ApplicationId);
            SetHeader(req, "X-Parse-REST-API-Key", ApiKey);
            req.Method = "POST";
            req.ContentType = MimeType;
            req.BeginGetRequestStream((iResult) =>
                {
                    var str = req.EndGetRequestStream(iResult);
                    str.Write(FileContent, 0, FileContent.Length);
                    req.BeginGetResponse((iiResult) => {
                        var resp = req.EndGetResponse(iiResult);
                        string result = "";
                        using (var sr = new StreamReader(resp.GetResponseStream()))
                            result = sr.ReadToEnd();
                        OnCompleted(result);
                    }, null);
                }, null);
            
        }
        //Modified from http://stackoverflow.com/questions/14534081/pcl-httpwebrequest-user-agent-on-wpf
        public static void SetHeader(HttpWebRequest Request, string Header, string Value) {
            // Retrieve the property through reflection.
            PropertyInfo PropertyInfo = Request.GetType().GetRuntimeProperty(Header.Replace("-", string.Empty));
            // Check if the property is available.
            if (PropertyInfo != null) {
                // Set the value of the header.
                PropertyInfo.SetValue(Request, Value, null);
            } else {
                // Set the value of the header.
                Request.Headers[Header] = Value;
            }
        }
