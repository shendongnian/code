    [XmlRoot("DocumentElement")]
    public class DocumentElement : List<Person>
    {
    }
    
    public class Person
    {
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string eMail { get; set; }
        public string PostCode { get; set; }
        public string Company { get; set; }
        public string TelephoneNumber { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
    }
