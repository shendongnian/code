    public class StackOverflow_31184719
    {
        [ServiceContract]
        public interface ITest
        {
            [WebGet(UriTemplate = "/foo?id={Id}&flags={flags}&filter={filter}", ResponseFormat = WebMessageFormat.Xml, BodyStyle = WebMessageBodyStyle.Wrapped)]
            [OperationContract]
            string GetFoo(string id, FlaggedEnum flags, SomeClass filter = null);
        }
        [Flags]
        public enum FlaggedEnum
        {
            [EnumMember]
            Book = 1,
            [EnumMember]
            Product = 2,
            [EnumMember]
            TenorGroup = 4,
            [EnumMember]
            Tenor = 8,
            [EnumMember]
            Trade = 16
        }
        public class SomeClass
        {
            public string SomeProperty { get; set; }
        }
        public class MyWebHttpBehavior : WebHttpBehavior
        {
            protected override QueryStringConverter GetQueryStringConverter(OperationDescription operationDescription)
            {
                return new MyConverter(base.GetQueryStringConverter(operationDescription));
            }
            class MyConverter : QueryStringConverter
            {
                QueryStringConverter inner;
                public MyConverter(QueryStringConverter inner)
                {
                    this.inner = inner;
                }
                public override bool CanConvert(Type type)
                {
                    return type == typeof(SomeClass) || this.inner.CanConvert(type);
                }
                public override object ConvertStringToValue(string parameter, Type parameterType)
                {
                    if (parameterType == typeof(SomeClass))
                    {
                        return new SomeClass { SomeProperty = parameter };
                    }
                    else
                    {
                        return base.ConvertStringToValue(parameter, parameterType);
                    }
                }
            }
        }
        public class Service : ITest
        {
            public string GetFoo(string id, FlaggedEnum flags, SomeClass filter = null)
            {
                return string.Format("{0} - {1} - {2}", id, flags, filter == null ? "<<NULL>>" : filter.SomeProperty);
            }
        }
        public static void Main()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITest), new WebHttpBinding(), "");
            endpoint.Behaviors.Add(new MyWebHttpBehavior());
            host.Open();
            Console.WriteLine("Host opened");
            WebClient c = new WebClient();
            Console.WriteLine(c.DownloadString(baseAddress + "/foo?id=MyId&flags=Book,Product&filter=MyFilter"));
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
