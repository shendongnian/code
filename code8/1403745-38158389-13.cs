    [XmlSchemaProvider("GetSchemaMethod")]
    public class Person : IXmlSerializable
    {
        // Private state
        private string personName;
        // Constructors
        public Person(string name)
        {
            personName = name;
        }
        public Person()
        {
            personName = null;
        }
        [ThreadStatic]
        static string personXmlTypeName;
        const string defaultXmlTypeName = "Person";
        static string PersonXmlTypeName
        {
            get
            {
                if (personXmlTypeName == null)
                    personXmlTypeName = defaultXmlTypeName;
                return personXmlTypeName;
            }
            set
            {
                personXmlTypeName = value;
            }
        }
        public static IDisposable PushXmlTypeName(string xmlTypeName)
        {
            return new PushValue<string>(xmlTypeName, () => PersonXmlTypeName, val => PersonXmlTypeName = val);
        }
        // This is the method named by the XmlSchemaProviderAttribute applied to the type.
        public static XmlQualifiedName GetSchemaMethod(XmlSchemaSet xs)
        {
            string EmployeeSchemaFormat = @"<?xml version=""1.0"" encoding=""utf-16""?>
                <xs:schema elementFormDefault=""qualified"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
                  <xs:import namespace=""http://www.w3.org/2001/XMLSchema"" />
                  <xs:element name=""{0}"" nillable=""true"" type=""{0}"" />
                  <xs:complexType name=""{0}"" mixed=""true"">
                  <xs:sequence>
                    <xs:any />
                  </xs:sequence>
                  </xs:complexType>
                </xs:schema>";
            var EmployeeSchema = string.Format(EmployeeSchemaFormat, PersonXmlTypeName);
            using (var textReader = new StringReader(EmployeeSchema))
            using (var schemaSetReader = System.Xml.XmlReader.Create(textReader))
            {
                xs.Add("", schemaSetReader);
            }
            return new XmlQualifiedName(PersonXmlTypeName);
        }
        // Xml Serialization Infrastructure
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteString(personName);
        }
        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            var isEmpty = reader.IsEmptyElement;
            reader.ReadStartElement();
            if (!isEmpty)
            {
                personName = reader.ReadContentAsString();
                reader.ReadEndElement();
            }
        }
        public XmlSchema GetSchema()
        {
            return (null);
        }
        // Print
        public override string ToString()
        {
            return (personName);
        }
    }
    public struct PushValue<T> : IDisposable
    {
        Action<T> setValue;
        T oldValue;
        public PushValue(T value, Func<T> getValue, Action<T> setValue)
        {
            if (getValue == null || setValue == null)
                throw new ArgumentNullException();
            this.setValue = setValue;
            this.oldValue = getValue();
            setValue(value);
        }
        #region IDisposable Members
        // By using a disposable struct we avoid the overhead of allocating and freeing an instance of a finalizable class.
        public void Dispose()
        {
            if (setValue != null)
                setValue(oldValue);
        }
        #endregion
    }
    public static class PersonEmployeeListSerializerFactory
    {
        static Dictionary<Tuple<string, string>, XmlSerializer> serializers;
        static object padlock = new object();
        static PersonEmployeeListSerializerFactory()
        {
            serializers = new Dictionary<Tuple<string, string>, XmlSerializer>();
        }
        public static XmlSerializer GetSerializer(string rootName, string personName)
        {
            lock (padlock)
            {
                XmlSerializer serializer;
                var key = Tuple.Create(rootName, personName);
                if (!serializers.TryGetValue(key, out serializer))
                {
                    using (Person.PushXmlTypeName(personName))
                    {
                        var lOverrides = new XmlAttributeOverrides();
                        //var lAttributes = new XmlAttributes();
                        //lOverrides.Add(typeof(Person), lAttributes);
                        serializers[key] = serializer = new XmlSerializer(typeof(List<Person>), lOverrides, new Type[0], new XmlRootAttribute(rootName), null);
                    }
                }
                return serializer;
            }
        }
    }
