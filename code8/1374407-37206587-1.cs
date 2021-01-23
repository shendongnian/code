    public class CompanyInfo
    { 
        public string companyName{ get;set;}
        public string companyNumber{ get;set;}
        public Address address{get;set;}
    }
    
    public class Address
    {
        public string buildingNumber{ get;set;}
        public string street{ get;set;}
        public string county{ get;set;}
        public string postalTown{ get;set;}
        public string postCode{ get;set;}
    }
