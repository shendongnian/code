        public static string SendFile(string FileName, string MimeType, byte[] FileContent, string ClientId, string ApplicationId, string ApiKey)
        { 
            string BaseServer =   "https://api.parse.com/{0}/files/{1}";
            HttpWebRequest req = HttpWebRequest.CreateHttp(string.Format(BaseServer, ClientId, FileName));
            req.Headers.Add("X-Parse-Application-Id", ApplicationId);
            req.Headers.Add("X-Parse-REST-API-Key", ApiKey);
            req.Method = "POST";
            req.ContentType = MimeType;
            req.ContentLength = FileContent.Length;
            using(var str = req.GetRequestStream())
                str.Write(FileContent, 0, FileContent.Length);
            var res = req.GetResponse();
            string result = "";
            using (var sr = new StreamReader(res.GetResponseStream()))
                result = sr.ReadToEnd();
            return result;
            
        }
