    public class PersonalDetails
    {
    
        [XmlElement(Order = 1)]
        public string Name { get; set; }
    
        [XmlElement(Order = 2)]
        public int Age { get; set; }
    
        [XmlElement(Order = 3)]
        public AddressDetails address;
        public PersonalDetails()
        {
    
        }
        public PersonalDetails(string Name, int Age, AddressDetails address)
        {
            this.Name = Name;
            this.Age = Age;
            this.address = address;
        }
    
        public class AddressDetails
        {
            [XmlElement(ElementName = "Number", Order = 1)]
            public int HouseNo;
            [XmlElement(ElementName = "Street", Order = 2)]
            public string StreetName;
            [XmlElement(Order = 3)]
            public string City;
            public AddressDetails()
            {
    
            }
            static void Main(string[] args)
            {
    
                AddressDetails address = new AddressDetails();
                PersonalDetails[] personal = new PersonalDetails[1];
                personal[0] = new PersonalDetails("Roberto", 15, address);
    
                address.HouseNo = 4;
                address.StreetName = "ABC";
                address.City = "Delhi";
    
                Serialize(personal[0]);
            }
            public static void Serialize(PersonalDetails personal)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(PersonalDetails));
                using (TextWriter writer = new StreamWriter("TestXML.xml"))
                {
                    serializer.Serialize(writer, personal);
                }
            }
        }
    }
