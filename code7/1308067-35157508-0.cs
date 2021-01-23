    [XmlRoot("results")]
    public class Results
    {
        [XmlElement("row")]
        public List<Employee> Employees { get; set; }
    }
    
    public class Employee
    {
        [XmlElement(ElementName = "id", Order = 1)]
        public string Id { set; get; }
        [XmlElement(ElementName = "field", Order = 2)]
        public string Firstname { set; get; }
        [XmlElement(ElementName = "field", Order = 3)]
        public string Lastname { set; get; }
        [XmlElement(ElementName = "field", Order = 4)]
        public string Country { set; get; }
        [XmlElement(ElementName = "field", Order = 5)]
        public string City { set; get; }
        [XmlElement(ElementName = "field", Order = 6)]
        public string Postcode { set; get; }
        [XmlElement(ElementName = "field", Order = 7)]
        public string Email { set; get; }
        [XmlElement(ElementName = "field", Order = 8)]
        public string Message { set; get; }
    }
