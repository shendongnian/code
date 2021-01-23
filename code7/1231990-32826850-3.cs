    [XmlRoot("places_info")]
    public class PlacesInfo
    {
        [XmlElement("place")]
        public Place[] Places { get; set; }
    }
    public class Place
    {
        [XmlElement("place_id")]
        public string Id { get; set; }
    
        [XmlElement("name")]
        public string Name { get; set; }
    
        [XmlElement("city")]
        public string City { get; set; }
    
        [XmlElement("address")]
        public string Address { get; set; }
    }
