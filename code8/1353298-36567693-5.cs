    [DataContract(Name = "rdlt", Namespace = "http://www.rdml.org")]
    public class Container
    {
        [DataMember]
        public DateTime created { get; set; }
        [DataMember]
        public DateTime updated { get; set; }
    }
    // deserialize (using your code!)
    var reader = XmlReader.Create(@"C:\tmp\test.xml");
    var serializer = new DataContractSerializer(typeof(Container));
    var obj = serializer.ReadObject(reader);
