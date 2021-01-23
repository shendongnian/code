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
        // This is the method named by the XmlSchemaProviderAttribute applied to the type.
        public static XmlQualifiedName GetSchemaMethod(XmlSchemaSet xs)
        {
            string EmployeeSchema = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <xs:schema elementFormDefault=""qualified"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
      <xs:import namespace=""http://www.w3.org/2001/XMLSchema"" />
      <xs:element name=""Employee"" nillable=""true"" type=""Employee"" />
      <xs:complexType name=""Employee"" mixed=""true"">
      <xs:sequence>
        <xs:any />
      </xs:sequence>
      </xs:complexType>
    </xs:schema>";
            using (var textReader = new StringReader(EmployeeSchema))
            using (var schemaSetReader = System.Xml.XmlReader.Create(textReader))
            {
                xs.Add("", schemaSetReader);
            }
            return new XmlQualifiedName("Employee");
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
