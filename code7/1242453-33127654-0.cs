    var map = new Dictionary<string, Type>
    {
       { "Demo.Car", typeof(Car) },
       { "Demo.Person", typeof(Person) },
       ...
    }
    var serializer = new XmlSerializer(map[classname]);
    using (var reader = new StringReader(xml))
    {
       var result = serializer.Deserialize(reader);
       ...
    }
