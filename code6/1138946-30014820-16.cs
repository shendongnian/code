    public class Address
    {
        [XmlElement("HouseNo")]
        public string HouseNo { get; set; }
        [XmlElement("StreetName")]
        public string StreetName{ get; set; }
        [XmlElement("City")]
        public string City{ get; set; }
        [XmlIgnore]
        public bool IsValid
        {
            get
            {
                return !string.IsNullOrEmpty(this.HouseNo)
                    && !string.IsNullOrEmpty(this.StreetName)
                    && !string.IsNullOrEmpty(this.City);
            }
        }
    }
