    var lSerialiser = PersonEmployeeListSerializer.Instance;
    var lNamespaces = new XmlSerializerNamespaces();
    lNamespaces.Add("", "");
    var sb = new StringBuilder();
    using (var writer = new StringWriter(sb))
        lSerialiser.Serialize(writer, lPersonList, lNamespaces);
    Console.WriteLine(sb);
