    var xsn = new XmlSerializerNamespaces();
    xsn.Add("a", "http://foo.co.uk/Contact");
    
    var xs = new XmlSerializer(typeof(CreateContact));
    
    using (var stringWriter = new StringWriter())
    {
        xs.Serialize(stringWriter, cc, xsn);
        xml = stringWriter.ToString();
    }
