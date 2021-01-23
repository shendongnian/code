    public class MainData
    {
        public List<Channel> listofChannels { get; set; }
    }
    [XmlType("item")]
    public class Channel
    {
        [XmlAttribute("type")]
        public string Type;
        [XmlElement("channelName")]
        public string Name;
        [XmlElement("channelPort")]
        public int Port;
        [XmlElement("ServerDetail")]
        public ChannelDetail details;
    }
    public class ChannelDetail
    {
        [XmlAttribute("ipaddress")]
        public string IPAddress { get; set; }
        [XmlAttribute("port")]
        public int Port { get; set; }
    }
