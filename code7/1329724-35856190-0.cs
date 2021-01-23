    [DataContract]
    [Serializable]
    public class Page
    {
        //This works.
        [DataMember]
        public Panel Panel { get; set; }
        //This works, too.
        [DataMember]
        public TwoColumnPanel TwoColumnPanel { get; set; }
        //For this one, however, I only get the one Panel when I deserialize.
        //Why doesn't it properly deserialize the TwoColumnPanel specified in the xml above.
        [DataMember]
        [XmlArray("Panels")]
        [XmlArrayItem("TwoColumnPanel", typeof(TwoColumnPanel))]
        [XmlArrayItem("Panel", typeof(Panel))]
        public List<Panel> Panels { get; set; }
    }
