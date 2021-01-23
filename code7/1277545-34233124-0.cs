    [XmlRoot("root")]
    [Serializable]
    public class Root
    {
        public Root() 
        {
            eConnects = new List<eConnect>();
        }
        [XmlElement("eConnect")]
        List<eConnect> eConnects { get; set; }
    }
    [XmlRoot("eConnect")]
    [Serializable]
    public class eConnect
    {
        [XmlElement("Customer")]
        public Customer customer { get; set; }
    }
    [XmlRoot("Customer")]
    [Serializable]
    public class Customer
    {
        [XmlElement("CUSTNMBR")]
        public string CUSTNMBR { get; set; }
        [XmlElement("CUSTNAME")]
        public string CUSTNAME { get; set; }
    }
