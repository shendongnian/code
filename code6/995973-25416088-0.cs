    public class StackOverflow_25377059
    {
        [ServiceContract]
        public interface ITestService
        {
            [OperationContract]
            [WebInvoke(Method = "POST",
             ResponseFormat = WebMessageFormat.Json,
             BodyStyle = WebMessageBodyStyle.Bare,
             UriTemplate = "/test")]
            string Test(Stream body);
        }
        public class Service : ITestService
        {
            public string Test(Stream body)
            {
                return new StreamReader(body).ReadToEnd();
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
            var baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            var host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            var binding = new WebHttpBinding { ContentTypeMapper = new RawMapper() };
            host.AddServiceEndpoint(typeof(ITestService), binding, "").Behaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            var req = (HttpWebRequest)HttpWebRequest.Create(baseAddress + "/test");
            req.Method = "POST";
            req.ContentType = "application/json";
            var reqStream = req.GetRequestStream();
            var body = "a test message";
            var bodyBytes = new UTF8Encoding(false).GetBytes(body);
            reqStream.Write(bodyBytes, 0, bodyBytes.Length);
            reqStream.Close();
            var resp = (HttpWebResponse)req.GetResponse();
            Console.WriteLine("HTTP/{0} {1} {2}", resp.ProtocolVersion, (int)resp.StatusCode, resp.StatusDescription);
            foreach (var header in resp.Headers.AllKeys)
            {
                Console.WriteLine("{0}: {1}", header, resp.Headers[header]);
            }
            Console.WriteLine();
            Console.WriteLine(new StreamReader(resp.GetResponseStream()).ReadToEnd());
            Console.WriteLine();
        }
    }
