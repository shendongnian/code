    class Program
    {
        static void Main(string[] args) {
            var filePath = @"c:\1.xml";
            dynamic expando = new SerilaizableExpandoObject();
            var serializer = new XmlSerializer(typeof(SerilaizableExpandoObject));
            expando.Name = "Anindya";
            expando.StackOverflowReputation = 100;
            using (var writer = new StreamWriter(filePath)) {
                serializer.Serialize(writer, expando);
            }
            expando = (SerilaizableExpandoObject)serializer.Deserialize(File.OpenRead(filePath));
            Console.WriteLine(expando.Name);
            Console.WriteLine(expando.StackOverflowReputation);
        }
    }
    public class SerilaizableExpandoObject : DynamicObject, IXmlSerializable
    {
        private readonly string root = "SerilaizableExpandoObject";
        private readonly IDictionary<string, object> expando = null;
        public SerilaizableExpandoObject() {
            expando = new ExpandoObject();
        }
        public override bool TryGetMember(GetMemberBinder binder, out object result) {
            object value;
            if (expando.TryGetValue(binder.Name, out value)) {
                result = value;
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value) {
            expando[binder.Name] = value;
            return true;
        }
        public XmlSchema GetSchema() {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader) {
            reader.ReadStartElement(root);
            while (!reader.Name.Equals(root)) {
                object value;
                string typeContent;
                Type underlyingType;
                var name = reader.Name;
                reader.MoveToAttribute("type");
                typeContent = reader.ReadContentAsString();
                underlyingType = Type.GetType(typeContent);
                reader.MoveToContent();
                expando[name] = reader.ReadElementContentAs(underlyingType, null);
            }
        }
        public void WriteXml(XmlWriter writer) {
            foreach (var key in expando.Keys) {
                var value = expando[key];
                writer.WriteStartElement(key);
                writer.WriteAttributeString("type", value.GetType().AssemblyQualifiedName);
                writer.WriteString(value.ToString());
                writer.WriteEndElement();
            }
        }
    }
