    [XmlSchemaProvider("GetSchemaMethod")]
    [XmlRoot(Namespace = "http://schemas.datacontract.org/2004/07/Question38741035")]
    public class MyClass : IXmlSerializable
    {
        public string PropertyA { get; set; }
        public decimal PropertyB { get; set; }
        const string XmlNamespace = "http://schemas.datacontract.org/2004/07/Question38741035";
        
        // This is the method named by the XmlSchemaProviderAttribute applied to the type.
        public static XmlQualifiedName GetSchemaMethod(XmlSchemaSet xs)
        {
            string schema = @"<?xml version=""1.0"" encoding=""utf-16""?>
    <xs:schema 
        xmlns:tns=""http://schemas.datacontract.org/2004/07/Question38741035"" 
        elementFormDefault=""qualified"" 
        targetNamespace=""http://schemas.datacontract.org/2004/07/Question38741035"" 
        xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
      <xs:complexType name=""MyClass"">
        <xs:sequence>
          <xs:element minOccurs=""0"" name=""PropertyA"" nillable=""true"" type=""xs:string"" />
          <xs:element minOccurs=""0"" name=""PropertyB"" type=""xs:decimal"" />
        </xs:sequence>
      </xs:complexType>
      <xs:element name=""MyClass"" nillable=""true"" type=""tns:MyClass"" />
    </xs:schema>";
            using (var textReader = new StringReader(schema))
            using (var schemaSetReader = System.Xml.XmlReader.Create(textReader))
            {
                xs.Add(XmlNamespace, schemaSetReader);
            }
            return new XmlQualifiedName("MyClass", XmlNamespace);
        }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            if (reader.IsEmptyElement)
            {
                reader.Read();
                return;
            }
            var node = (XElement)XNode.ReadFrom(reader);
            if (node != null)
            {
                var ns = (XNamespace)XmlNamespace;
                PropertyA = (string)node.Element(ns + "PropertyA");
                PropertyB = (decimal)node.Element(ns + "PropertyB");
            }
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            if (PropertyA != null)
                writer.WriteElementString("PropertyA", XmlNamespace, PropertyA);
            writer.WriteStartElement("PropertyB", XmlNamespace);
            writer.WriteValue(PropertyB);
            writer.WriteEndElement();
        }
        #endregion
    }
