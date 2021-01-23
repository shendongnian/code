    public class StackOverflow_36918281
    {
        [DataContract] public class ObjectToBeReturned
        {
            [DataMember]
            public string A { get; set; }
            [DataMember]
            public string B { get; set; }
        }
        [ServiceContract]
        public interface ITest
        {
            [OperationContract, WebGet(ResponseFormat = WebMessageFormat.Json)]
            ObjectToBeReturned Test();
        }
        public class Service : ITest
        {
            public ObjectToBeReturned Test()
            {
                return new ObjectToBeReturned { A = "atest", B = "btest" };
            }
        }
        public class MyJsonWrapperInspector : IEndpointBehavior, IDispatchMessageInspector
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                return null;
            }
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
            }
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(this);
            }
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
                object propValue;
                if (reply.Properties.TryGetValue(WebBodyFormatMessageProperty.Name, out propValue) &&
                    ((WebBodyFormatMessageProperty)propValue).Format == WebContentFormat.Json)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(reply.GetReaderAtBodyContents());
                    var newRoot = doc.CreateElement("root");
                    SetTypeAttribute(doc, newRoot, "object");
                    var status = doc.CreateElement("status");
                    SetTypeAttribute(doc, status, "string");
                    status.AppendChild(doc.CreateTextNode("success"));
                    newRoot.AppendChild(status);
                    var newData = doc.CreateElement("data");
                    SetTypeAttribute(doc, newData, "object");
                    newRoot.AppendChild(newData);
                    var data = doc.DocumentElement;
                    var toCopy = new List<XmlNode>();
                    foreach (XmlNode child in data.ChildNodes)
                    {
                        toCopy.Add(child);
                    }
                    foreach (var child in toCopy)
                    {
                        newData.AppendChild(child);
                    }
                    Console.WriteLine(newRoot.OuterXml);
                    var newReply = Message.CreateMessage(reply.Version, reply.Headers.Action, new XmlNodeReader(newRoot));
                    foreach (var propName in reply.Properties.Keys)
                    {
                        newReply.Properties.Add(propName, reply.Properties[propName]);
                    }
                    reply = newReply;
                }
            }
            private void SetTypeAttribute(XmlDocument doc, XmlElement element, string value)
            {
                var attr = element.Attributes["type"];
                if (attr == null)
                {
                    attr = doc.CreateAttribute("type");
                    attr.Value = value;
                    element.Attributes.Append(attr);
                }
                else
                {
                    attr.Value = value;
                }
            }
            public void Validate(ServiceEndpoint endpoint)
            {
            }
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            string baseAddressTcp = "net.tcp://" + Environment.MachineName + ":8888/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress), new Uri(baseAddressTcp));
            var ep1 = host.AddServiceEndpoint(typeof(ITest), new NetTcpBinding(), "");
            var ep2 = host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "");
            ep2.EndpointBehaviors.Add(new WebHttpBehavior());
            ep2.EndpointBehaviors.Add(new MyJsonWrapperInspector());
            host.Open();
            Console.WriteLine("Host opened");
            Console.WriteLine("TCP:");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(new NetTcpBinding(), new EndpointAddress(baseAddressTcp));
            ITest proxy = factory.CreateChannel();
            Console.WriteLine(proxy.Test());
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.WriteLine();
            Console.WriteLine("Web:");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/Test"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
