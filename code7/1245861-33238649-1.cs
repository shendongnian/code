    // Create a name space prefix
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("ns1", "ttp://www.w3.org/XML/2008/xsdl-exx/ns1");
    // Create a serializer
    System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(this.GetType());
    // And pass the namespace along as param
    ser.Serialize(writer, this, ns)
