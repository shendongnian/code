    XmlSerializer ser = new XmlSerializer(typeof(List<Employee>), 
                                          new XmlRootAttribute("Employees"));
            
    TextWriter writer = new StreamWriter(filename);
    var xmlWriter = XmlWriter.Create(writer, new XmlWriterSettings() { OmitXmlDeclaration = true });
    XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
    ns.Add("", "");
    ser.Serialize(xmlWriter, list, ns);
