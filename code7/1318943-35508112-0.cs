    <AddressDetails>
        <HouseNo>4</HouseNo>
        <StreetName>Rohini</StreetName>
        <City>Delhi</City>
    </AddressDetails>
    public class AddressDetails
    { 
        [XmlElement("Number")]
        public int HouseNo { get; set; }
        [XmlElement("Street")] 
        public  string StreetName { get; set; } 
        [XmlElement("CityName")]
    }
    public static void Main(string[] args) 
    { 
        AddressDetails details = new AddressDetails();
        details.HouseNo = 4;
        details.StreeName = "Rohini";
        details.City = "Delhi";
        Serialize(details);
    }   
    static public void Serialize(AddressDetails details)
    { 
        XmlSerializer serializer = new XmlSerializer(typeof(AddressDetails)); 
        using (TextWriter writer = new StreamWriter(@"C:\Xml.xml"))
        {
            serializer.Serialize(writer, details); 
        } 
    }
