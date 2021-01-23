    public class Address
        {
            public string buildingNumber { get; set; }
            public string street { get; set; }
            public string county { get; set; }
            public string postalTown { get; set; }
            public string postcode { get; set; }
        }
        
        public class RootObject
        {
            public string companyName { get; set; }
            public string companyNumber { get; set; }
            public Address address { get; set; }
        }
