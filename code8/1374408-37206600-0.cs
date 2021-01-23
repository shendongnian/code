        var json = {  
                     "companyName":"Test company",
                     "companyNumber":"1234",
                     "address":{  
                         "buildingNumber":"33",
                         "street":"Caledon Road",
                         "county":"Barking and Dagenham",
                         "postalTown":"Essex",
                         "postcode":"E62HE"
                      }
                   }
     public class CompanyInfo
        { 
        public string companyName{ get;set;}
        public string companyNumber{ get;set;}
        public string buildingNumber{ get;set;}
        public Address address {get;set;}
        }
    
     public class Address
       {
        public string street{ get;set;}
        public string county{ get;set;}
        public string postalTown{ get;set;}
        public string postCode{ get;set;}
       }
