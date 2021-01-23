    [Test]
    public void SerializerTest()
    {
        var s = new SerializeMe(2);
        s.Name = "Test";
        DataContractSerializer dcs = new DataContractSerializer(typeof(SerializeMe));
        Stream ms = new MemoryStream();
        var writer = XmlWriter.Create(ms);
        Assert.DoesNotThrow(() => dcs.WriteObject(writer, s));
        writer.Close();
    
        ms.Position = 0;
        var reader = new StreamReader(ms);
        var xml = reader.ReadToEnd();
        Console.WriteLine(xml);
    }
    
    [Test]
    public void DeserializeTest()
    {
        var xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?><SerializeMe xmlns:i=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns=\"http://schemas.datacontract.org/2004/07/Test\"><Id>2</Id><Name>Test</Name></SerializeMe>";
        DataContractSerializer dcs = new DataContractSerializer(typeof(SerializeMe));            
        XmlReader reader = XmlReader.Create(new StringReader(xml));
        var obj = dcs.ReadObject(reader) as SerializeMe;
        Assert.AreEqual(obj.Name, "Test");
    }
    
    [DataContract]
    public class SerializeMe
    {
        public SerializeMe(int id)
        {
            this.Id = id;
        }
        [DataMember]
        public int Id { get; private set; }
        [DataMember]
        public string Name { get; set; }
    }
