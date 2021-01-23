    var car = new Car { name = "Hellcat", a = 10 };
    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(Car));
    string carXml = null;
    using (var ms = new System.IO.MemoryStream())
    {
        serializer.Serialize(ms, car);
        carXml = System.Text.Encoding.UTF8.GetString(ms.ToArray());
    }
