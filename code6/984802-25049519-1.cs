    [DataContract(Namespace = "")]
    public class Plan
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public Zone[] Zones { get; set; }
        [XmlIgnore]
        //assumes .NET 3.5+ for LINQ method, otherwise return new List<Zone>(Zones);
        public List<Zone> ZoneList { get { return Zones.ToList(); } }
    }
    [DataContract]
    public class Zone
    {
        [DataMember]
        public string Id { get; set; }
    }
