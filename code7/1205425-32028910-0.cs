    public class One
    {
        public string Foo { get; set; }
    }
    public class Two
    {
        public string Bar { get; set; }
    }
    var one = new One { Foo = "foo" };
    var two = new Two { Bar = "bar" };
    // Serialization two different class in one file
    var settings = new XmlWriterSettings { Indent = true };
    using (var writer = XmlWriter.Create("test.txt", settings))
    {
        // Create root node
        writer.WriteStartElement("root");
        var xs = new XmlSerializer(typeof(One));
        xs.Serialize(writer, one);
        xs = new XmlSerializer(typeof(Two));
        xs.Serialize(writer, two);
    }
    // Deserialization two different class from one file
    using (var reader = XmlReader.Create("test.txt"))
    {
        // Skip root node
        reader.ReadToFollowing("One"); // Name of first class
        var xs = new XmlSerializer(typeof(One));
        One first = (One)xs.Deserialize(reader);
        xs = new XmlSerializer(typeof(Two));
        Two second = (Two)xs.Deserialize(reader);
    }
