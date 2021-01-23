    public class InstanceSerializer : XmlObjectSerializer
    {
        const string localName = "instance";
    
        public override bool IsStartObject(XmlDictionaryReader reader)
        {
            return String.Equals(reader.LocalName, localName, StringComparison.OrdinalIgnoreCase);
        }
    
        public override object ReadObject(XmlDictionaryReader reader, bool verifyObjectName)
        {
            string xml = reader.ReadOuterXml();
            XDocument doc = XDocument.Parse(xml);
    
            string shortCode = doc.Descendants()
                .Where(e => e.Name.LocalName == "ShortCode")
                .Select(e => e.Value)
                .FirstOrDefault();
    
            string connStr = doc.Descendants()
                .Where(e => e.Name.LocalName == "ConnectionString")
                .Select(e => e.Value)
                .FirstOrDefault();
    
            if (connStr != null || shortCode != null) // Instance passed as Instance object
            {
                return new Instance(shortCode, connStr);
            }
    
            // Instance passed as String
            Instance instance = ((XElement) doc.FirstNode).Value;
            return instance;
        }
    
        public override void WriteEndObject(XmlDictionaryWriter writer)
        {
            writer.WriteEndElement();
        }
    
        public override void WriteObjectContent(XmlDictionaryWriter writer, object graph)
        {
        }
    
        public override void WriteStartObject(XmlDictionaryWriter writer, object graph)
        {
            writer.WriteStartElement(localName);
        }
    }
    
    public class InstanceBehavior : DataContractSerializerOperationBehavior
    {
        public InstanceBehavior(OperationDescription operation) : base(operation) { }
    
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return typeof(Instance) == type
                ? new InstanceSerializer()
                : base.CreateSerializer(type, name, ns, knownTypes);
        }
    
        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return typeof(Instance) == type
                ? new InstanceSerializer()
                : base.CreateSerializer(type, name, ns, knownTypes);
        }
    }
    
    public class SupportStringInstanceAttribute : Attribute, IContractBehavior
    {
        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }
    
        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            ReplaceSerializerOperationBehavior(contractDescription);
        }
    
        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.DispatchRuntime dispatchRuntime)
        {
            ReplaceSerializerOperationBehavior(contractDescription);
        }
    
        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
    
        private static void ReplaceSerializerOperationBehavior(ContractDescription contract)
        {
            foreach (OperationDescription od in contract.Operations)
            {
                for (int i = 0; i < od.Behaviors.Count; i++)
                {
                    DataContractSerializerOperationBehavior dcsob = od.Behaviors[i] as DataContractSerializerOperationBehavior;
                    if (dcsob != null)
                    {
                        od.Behaviors[i] = new InstanceBehavior(od);
                    }
                }
            }
        }
    }
