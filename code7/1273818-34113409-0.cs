		private const string Url = "http://services.runescape.com/m=hiscore_oldschool/overall.ws";
        
        private static HttpWebRequest BuildWebRequest()
        {
            var request = WebRequest.Create(Url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.Timeout = 40000;
            request.ServicePoint.Expect100Continue = true;
            
            string body = "user1=Zezima&submit=Search";
            byte[] bytes = Encoding.Default.GetBytes(body);
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            return request;
            
        }
        static void Main(string[] args)
        {
                try
                {
                    HttpWebRequest request = BuildWebRequest();
                        
                    var response = request.GetResponse() as HttpWebResponse;
                    var responseContent = new StreamReader(response.GetResponseStream()).ReadToEnd();
	                Console.Write("Success - " + response.StatusCode);
                }
                catch (Exception e)
                {
                     Console.Write(e);
                }
        }
