    public class StackOverflow_35921627
    {
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            [WebInvoke(BodyStyle = WebMessageBodyStyle.WrappedRequest, ResponseFormat = WebMessageFormat.Json)]
            string Login(string host, string user, string pass, string applicationId);
        }
        public class Service : ITest
        {
            public string Login(string host, string user, string pass, string applicationId)
            {
                return string.Format("Login result: {0} - {1} - {2} - {3}", host, user, pass, applicationId);
            }
        }
        public class MyWebHttpBehavior : WebHttpBehavior
        {
            protected override IDispatchMessageFormatter GetRequestDispatchFormatter(OperationDescription operationDescription, ServiceEndpoint endpoint)
            {
                var originalFormatter = base.GetRequestDispatchFormatter(operationDescription, endpoint);
                return new FormDataDispatchFormatter(operationDescription, originalFormatter);
            }
        }
        public class FormDataDispatchFormatter : IDispatchMessageFormatter
        {
            IDispatchMessageFormatter originalFormatter;
            Dictionary<string, int> parameterNames;
            public FormDataDispatchFormatter(OperationDescription operation, IDispatchMessageFormatter originalFormatter)
            {
                var inputMessageBodyParts = operation.Messages[0].Body.Parts;
                this.parameterNames = new Dictionary<string, int>();
                for (int i = 0; i < inputMessageBodyParts.Count; i++)
                {
                    if (inputMessageBodyParts[i].Type == typeof(string))
                    {
                        // For now, only support string parameters; others will be ignored
                        this.parameterNames.Add(inputMessageBodyParts[i].Name, i);
                    }
                }
                this.originalFormatter = originalFormatter;
            }
            public void DeserializeRequest(Message message, object[] parameters)
            {
                object httpRequestProperty;
                if (!message.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestProperty))
                {
                    throw new InvalidOperationException("This formatter can only be used with HTTP");
                }
                var contentType = ((HttpRequestMessageProperty)httpRequestProperty).Headers[HttpRequestHeader.ContentType];
                if (contentType == null || !contentType.StartsWith("application/x-www-form-urlencoded"))
                {
                    this.originalFormatter.DeserializeRequest(message, parameters);
                    return;
                }
                object bodyFormatProperty;
                if (!message.Properties.TryGetValue(WebBodyFormatMessageProperty.Name, out bodyFormatProperty) ||
                    (bodyFormatProperty as WebBodyFormatMessageProperty).Format != WebContentFormat.Raw)
                {
                    throw new InvalidOperationException("Incoming messages must have a body format of Raw. Is a ContentTypeMapper set on the WebHttpBinding?");
                }
                XmlDictionaryReader bodyReader = message.GetReaderAtBodyContents();
                bodyReader.ReadStartElement("Binary");
                byte[] rawBody = bodyReader.ReadContentAsBase64();
                MemoryStream ms = new MemoryStream(rawBody);
                StreamReader sr = new StreamReader(ms);
                string formData = sr.ReadToEnd();
                string[] parts = formData.Split('&');
                foreach (var part in parts)
                {
                    // TODO: handle url-decoding
                    var kvp = part.Split('=');
                    if (kvp.Length != 2)
                    {
                        throw new InvalidOperationException("Only support simple parameters for now");
                    }
                    int index;
                    if (this.parameterNames.TryGetValue(kvp[0], out index))
                    {
                        parameters[index] = kvp[1];
                    }
                }
            }
            public Message SerializeReply(MessageVersion messageVersion, object[] parameters, object result)
            {
                throw new NotSupportedException("This is a request-only formatter");
            }
        }
        internal static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new MyWebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            SendPostRequest(baseAddress + "/Login", "application/x-www-form-urlencoded", "host=myHost&user=myUser&pass=myPassword&applicationId=app123");
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
        static void SendPostRequest(string url, string contentType, string body)
        {
            HttpWebRequest req = HttpWebRequest.CreateHttp(url);
            req.Method = "POST";
            req.ContentType = contentType;
            byte[] bodyBytes = Encoding.UTF8.GetBytes(body);
            Stream reqStream = req.GetRequestStream();
            reqStream.Write(bodyBytes, 0, bodyBytes.Length);
            reqStream.Close();
            HttpWebResponse resp;
            try
            {
                resp = (HttpWebResponse)req.GetResponse();
            }
            catch (WebException ex)
            {
                resp = (HttpWebResponse)ex.Response;
            }
            if (resp == null)
            {
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
                    Console.WriteLine(new StreamReader(respStream).ReadToEnd());
                }
                else
                {
                    Console.WriteLine("HttpWebResponse.GetResponseStream returned null");
                }
            }
            Console.WriteLine();
            Console.WriteLine("  *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*  ");
            Console.WriteLine();
        }
    }
