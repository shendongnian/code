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
    public class SerilaizableExpandoObject : DynamicObject, IXmlSerializable, IDictionary<string, object>
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
        public void Add(string key, object value) {
            expando.Add(key, value);
        }
        public bool ContainsKey(string key) {
            return expando.ContainsKey(key);
        }
        public ICollection<string> Keys {
            get { return expando.Keys; }
        }
        public bool Remove(string key) {
            return expando.Remove(key);
        }
        public bool TryGetValue(string key, out object value) {
            return expando.TryGetValue(key, out value);
        }
        public ICollection<object> Values {
            get { return expando.Values; }
        }
        public object this[string key] {
            get {
                return expando[key];
            }
            set {
                expando[key] = value;
            }
        }
        public void Add(KeyValuePair<string, object> item) {
            expando.Add(item);
        }
        public void Clear() {
            expando.Clear();
        }
        public bool Contains(KeyValuePair<string, object> item) {
            return expando.Contains(item);
        }
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex) {
            expando.CopyTo(array, arrayIndex);
        }
        public int Count {
            get { return expando.Count; }
        }
        public bool IsReadOnly {
            get { return expando.IsReadOnly; }
        }
        public bool Remove(KeyValuePair<string, object> item) {
            return expando.Remove(item);
        }
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator() {
            return expando.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return this.GetEnumerator();
        }
    }
