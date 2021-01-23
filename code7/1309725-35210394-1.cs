        public static void SendFile(string FileName, string MimeType, byte[] FileContent, string ClientId, string ApplicationId, string ApiKey, Action<string> OnCompleted)
        { 
            string BaseServer =   "https://api.parse.com/{0}/files/{1}";
            HttpWebRequest req = HttpWebRequest.CreateHttp(string.Format(BaseServer, ClientId, FileName));
            req.Headers.Add("X-Parse-Application-Id", ApplicationId);
            req.Headers.Add("X-Parse-REST-API-Key", ApiKey);
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
                    });
                });
            
        }
