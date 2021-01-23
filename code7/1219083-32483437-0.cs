    static void Main(string[] args)
    {
        var value = new Class1() { SomeProperty = "content' asdasd' asdasd" };
        var settings = new XmlWriterSettings()
        {
            OmitXmlDeclaration = true,
            Encoding = Encoding.ASCII
        };
        var serializer = new XmlSerializer(typeof(Class1));
        string output = string.Empty;
        var nameSpaces = new XmlSerializerNamespaces();
        nameSpaces.Add(string.Empty, string.Empty);
        using (StringWriter textWriter = new StringWriter())
        {
            using (XmlWriter xmlWriter = XmlWriter.Create(textWriter, settings))
            {
                serializer.Serialize(xmlWriter, value, nameSpaces);
            }
            output = textWriter.ToString();
            Console.WriteLine(output);
        }
        string newOutput = output.Replace('\'', 'x');
        Console.WriteLine(newOutput);
    }
