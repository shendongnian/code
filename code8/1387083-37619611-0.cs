    public class StackOverflow_37597194
    {
        [ServiceContract]
        public interface ITest
        {
            [WebInvoke(Method = "POST",
                UriTemplate = "/payload",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                BodyStyle = WebMessageBodyStyle.Bare)]
            string payload(RequestPayload jsondata);
        }
        [DataContract]
        public class RequestPayload
        {
            [DataMember(Name = "_links")]
            public RequestPayloadLinks Links { get; set; }
            [DataMember(Name = "currency")]
            public string Currency { get; set; }
            [DataMember(Name = "status")]
            public string Status { get; set; }
            [DataMember(Name = "total")]
            public double Total { get; set; }
        }
        [DataContract] public class LinkObject
        {
            [DataMember(Name = "href")]
            public string Href { get; set; }
        }
        [DataContract]
        public class RequestPayloadLinks
        {
            [DataMember(Name = "self")]
            public LinkObject Self { get; set; }
            [DataMember(Name = "warehouse")]
            public LinkObject Warehouse { get; set; }
            [DataMember(Name = "invoice")]
            public LinkObject Invoice { get; set; }
        }
        public class Service : ITest
        {
            public string payload(RequestPayload jsondata)
            {
                return string.Format("{0} - {1} {2}", jsondata.Status, jsondata.Total, jsondata.Currency);
            }
        }
        public class JsonHalMapper : WebContentTypeMapper
        {
            public override WebContentFormat GetMessageFormatForContentType(string contentType)
            {
                if (contentType.StartsWith("application/hal+json"))
                {
                    return WebContentFormat.Json;
                }
                else
                {
                    return WebContentFormat.Default;
                }
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            var endpoint = host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding { ContentTypeMapper = new JsonHalMapper() }, "");
            endpoint.EndpointBehaviors.Add(new WebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            var requestData = @"   {
                '_links': {
                    'self': { 'href': '/orders/523' },
                    'warehouse': { 'href': '/warehouse/56' },
                    'invoice': { 'href': '/invoices/873' }
                },
                'currency': 'USD',
                'status': 'shipped',
                'total': 10.20
            }".Replace('\'', '\"');
            Console.WriteLine(requestData);
            c.Headers[HttpRequestHeader.ContentType] = "application/hal+json";
            try
            {
                var response = c.UploadString(baseAddress + "/payload", "POST", requestData);
                Console.WriteLine(response);
            }
            catch (WebException ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
