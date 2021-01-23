    [XmlRoot("Order", Namespace = null)]
    public class Order
    {
        [XmlElement("Number")]
        public Number Number;
        [XmlElement("TrackStartDateTime")]
        public string TrackStartDateTime;         
        [XmlElement("Notifications")]
        public Notifications Notifications;
        [XmlElement("Carrier")]
        public Carrier Carrier;       
   
