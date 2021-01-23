    public class StackOverflow_39082986
    {
        const string TimestampPropertyName = "MyTimestampProperty";
        class MyTimestampProperty
        {
            public DateTime EncoderTimestamp;
            public DateTime InspectorTimestamp;
        }
        [ServiceContract]
        public interface ITest
        {
            [OperationContract]
            void DoSomething();
        }
        public class Service : ITest
        {
            public void DoSomething()
            {
                var myProp = (MyTimestampProperty)OperationContext.Current.IncomingMessageProperties[TimestampPropertyName];
                var now = DateTime.UtcNow;
                Console.WriteLine("Request timestamps:");
                var timeFormat = "yyyy-MM-dd HH:MM:ss.fffffff";
                Console.WriteLine("  From encoder  : {0}", myProp.EncoderTimestamp.ToString(timeFormat));
                Console.WriteLine("  From inspector: {0}", myProp.InspectorTimestamp.ToString(timeFormat));
                Console.WriteLine("  From operation: {0}", now.ToString(timeFormat));
            }
        }
        class MyInspector : IEndpointBehavior, IDispatchMessageInspector
        {
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                MyTimestampProperty prop;
                if (request.Properties.ContainsKey(TimestampPropertyName))
                {
                    prop = (MyTimestampProperty)request.Properties[TimestampPropertyName];
                }
                else
                {
                    prop = new MyTimestampProperty();
                    request.Properties.Add(TimestampPropertyName, prop);
                }
                prop.InspectorTimestamp = DateTime.UtcNow;
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
            }
            public void Validate(ServiceEndpoint endpoint)
            {
            }
        }
        public class MyEncoderBindingElement : MessageEncodingBindingElement
        {
            private MessageEncodingBindingElement inner;
            public MyEncoderBindingElement(MessageEncodingBindingElement inner)
            {
                this.inner = inner;
            }
            public override MessageVersion MessageVersion
            {
                get { return this.inner.MessageVersion; }
                set { this.inner.MessageVersion = value; }
            }
            public override BindingElement Clone()
            {
                return new MyEncoderBindingElement((MessageEncodingBindingElement)this.inner.Clone());
            }
            public override MessageEncoderFactory CreateMessageEncoderFactory()
            {
                return new MyEncoderFactory(this.inner.CreateMessageEncoderFactory());
            }
            public override bool CanBuildChannelListener<TChannel>(BindingContext context)
            {
                return context.CanBuildInnerChannelListener<TChannel>();
            }
            public override IChannelListener<TChannel> BuildChannelListener<TChannel>(BindingContext context)
            {
                context.BindingParameters.Add(this);
                return context.BuildInnerChannelListener<TChannel>();
            }
            class MyEncoderFactory : MessageEncoderFactory
            {
                MessageEncoderFactory inner;
                public MyEncoderFactory(MessageEncoderFactory inner)
                {
                    this.inner = inner;
                }
                public override MessageEncoder Encoder
                {
                    get
                    {
                        return new MyEncoder(this.inner.Encoder);
                    }
                }
                public override MessageVersion MessageVersion
                {
                    get { return this.inner.MessageVersion; }
                }
            }
            class MyEncoder : MessageEncoder
            {
                MessageEncoder inner;
                public MyEncoder(MessageEncoder inner)
                {
                    this.inner = inner;
                }
                public override string ContentType
                {
                    get { return this.inner.ContentType; }
                }
                public override string MediaType
                {
                    get { return this.inner.MediaType; }
                }
                public override MessageVersion MessageVersion
                {
                    get { return this.inner.MessageVersion; }
                }
                public override bool IsContentTypeSupported(string contentType)
                {
                    return this.inner.IsContentTypeSupported(contentType);
                }
                public override Message ReadMessage(ArraySegment<byte> buffer, BufferManager bufferManager, string contentType)
                {
                    var result = this.inner.ReadMessage(buffer, bufferManager, contentType);
                    result.Properties.Add(TimestampPropertyName, new MyTimestampProperty { EncoderTimestamp = DateTime.UtcNow });
                    return result;
                }
                public override Message ReadMessage(Stream stream, int maxSizeOfHeaders, string contentType)
                {
                    var result = this.inner.ReadMessage(stream, maxSizeOfHeaders, contentType);
                    result.Properties.Add(TimestampPropertyName, new MyTimestampProperty { EncoderTimestamp = DateTime.UtcNow });
                    return result;
                }
                public override void WriteMessage(Message message, Stream stream)
                {
                    this.inner.WriteMessage(message, stream);
                }
                public override ArraySegment<byte> WriteMessage(Message message, int maxMessageSize, BufferManager bufferManager, int messageOffset)
                {
                    return this.inner.WriteMessage(message, maxMessageSize, bufferManager, messageOffset);
                }
            }
        }
        static Binding GetBinding(bool server)
        {
            var result = new CustomBinding(new BasicHttpBinding());
            if (server)
            {
                for (var i = 0; i < result.Elements.Count; i++)
                {
                    var mebe = result.Elements[i] as MessageEncodingBindingElement;
                    if (mebe != null)
                    {
                        result.Elements[i] = new MyEncoderBindingElement(mebe);
                        break;
                    }
                }
            }
            return result;
        }
        public static void Test()
        {
            string baseAddress = "http://" + Environment.MachineName + ":8000/Service";
            ServiceHost host = new ServiceHost(typeof(Service), new Uri(baseAddress));
            ServiceEndpoint endpoint = host.AddServiceEndpoint(typeof(ITest), GetBinding(true), "");
            endpoint.EndpointBehaviors.Add(new MyInspector());
            host.Open();
            Console.WriteLine("Host opened");
            ChannelFactory<ITest> factory = new ChannelFactory<ITest>(GetBinding(false), new EndpointAddress(baseAddress));
            ITest proxy = factory.CreateChannel();
            proxy.DoSomething();
            ((IClientChannel)proxy).Close();
            factory.Close();
            Console.Write("Press ENTER to close the host");
            Console.ReadLine();
            host.Close();
        }
    }
