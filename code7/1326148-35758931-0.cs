    public class StackOverflow_35750073
    {
        [ServiceContract]
        public class Service
        {
            [OperationContract]
            [WebInvoke(Method = "POST", UriTemplate = "data")]
            public Stream GetData(Stream iBody)
            {
                StreamReader objReader = new StreamReader(iBody);
                string strBody = objReader.ReadToEnd();
                XmlDocument objDoc = new XmlDocument();
                objDoc.LoadXml(strBody);
                return GetStreamData("Hello There. " + objDoc.InnerText);
            }
            private Stream GetStreamData(string iContent)
            {
                byte[] resultBytes = Encoding.UTF8.GetBytes(iContent);
                return new MemoryStream(resultBytes);
            }
        }
        class RawMapper : WebContentTypeMapper
        {
            public override WebContentFormat GetMessageFormatForContentType(string contentType)
            {
                return WebContentFormat.Raw;
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint1 = host.AddServiceEndpoint(
                typeof(Service),
                new WebHttpBinding { ContentTypeMapper = new RawMapper() },
                "withMapper");
            endpoint1.Behaviors.Add(new WebHttpBehavior());
            ServiceEndpoint endpoint2 = host.AddServiceEndpoint(
                typeof(Service), 
                new WebHttpBinding(),
                "noMapper");
            endpoint2.Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            var input = "<hello><world>How are you?</world></hello>";
            Console.WriteLine("Using a Content-Type mapper:");
            SendRequest(baseAddress + "/withMapper/data", "POST", "text/xml", input);
            SendRequest(baseAddress + "/withMapper/data", "POST", null, input);
            Console.WriteLine("Without using a Content-Type mapper:");
            SendRequest(baseAddress + "/noMapper/data", "POST", "text/xml", input);
            SendRequest(baseAddress + "/noMapper/data", "POST", null, input);
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
        public static string SendRequest(string uri, string method, string contentType, string body)
        {
            string responseBody = null;
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(uri);
            req.Method = method;
            if (!String.IsNullOrEmpty(contentType))
            {
                req.ContentType = contentType;
            }
            if (body != null)
            {
                byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
                req.GetRequestStream().Write(bodyBytes, 0, bodyBytes.Length);
                req.GetRequestStream().Close();
            }
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException e)
            {
                resp = (HttpWebResponse)e.Response;
            }
            if (resp == null)
            {
                responseBody = null;
                Console.WriteLine("Response is null");
            }
            else
            {
                Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
                foreach (string headerName in resp.Headers.AllKeys)
                {
                    Console.WriteLine("{0}: {1}", headerName, resp.Headers[headerName]);
                }
                Console.WriteLine();
                Stream respStream = resp.GetResponseStream();
                if (respStream != null)
                {
                    responseBody = new StreamReader(respStream).ReadToEnd();
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine("HttpWebResponse.GetResponseStream returned null");
                }
            }
            Console.WriteLine();
            Console.WriteLine("  *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*  ");
            Console.WriteLine();
            return responseBody;
        }
    }
