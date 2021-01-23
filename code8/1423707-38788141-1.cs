    var dummy = new Dummy { DummyProperty = DateTime.Now };
    Console.WriteLine(dummy.DummyProperty);
    var xs = new XmlSerializer(typeof(Dummy));
    string xml;
    using (var stringWriter = new StringWriter())
    using (var xmlWriter = new CustomDateTimeWriter(stringWriter))
    {
        xmlWriter.Formatting = Formatting.Indented;
        xs.Serialize(xmlWriter, dummy);
        xml = stringWriter.ToString();
    }
    Console.WriteLine(xml);
    using (var stringReader = new StringReader(xml))
    using (var xmlReader = new CustomDateTimeReader(stringReader))
    {
        dummy = (Dummy)xs.Deserialize(xmlReader);
        Console.WriteLine(dummy.DummyProperty);
    }
