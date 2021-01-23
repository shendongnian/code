    D x = new D();
    string xml;
    using(var sw = new StringWriter())
    {
        var serializer = new XmlSerializer(typeof(B));
        serializer.Serialize(sw, x);
        xml = sw.ToString();
    }
    
    B x2;
    using(var sr = new StringReader(xml)) 
    {
        var serializer = new XmlSerializer(typeof(B));
        x2 = serializer.Deserialize(sr) as B;
    }
    // if you check instance of x2 in debug, it will be of type D
