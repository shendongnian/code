        static void Main(string[] args)
        {
              HttpWebRequest request = BuildWebRequest();
                        
              var response = request.GetResponse() as HttpWebResponse;
              var responseContent = new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
		private static HttpWebRequest BuildWebRequest()
        {
            var request = WebRequest.Create(Url) as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/xml";
            request.Timeout = 40000;
            request.ServicePoint.Expect100Continue = true;
            string body = @"<?xml version="1.0"?>
    <methodCall>
      <methodName>examples.getStateName</methodName>
      <params>
        <param>
            <value><i4>40</i4></value>
        </param>
      </params>
    </methodCall>";
            byte[] bytes = Encoding.Default.GetBytes(body);
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }
            return request;
        }
