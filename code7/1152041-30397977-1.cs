        public class UserDTO
        {
        public int UserId {get;set;}
        public string UserName {get;set;}
        
    // HERE IF YOU HAVE:
    // public PersonDTO MyPerson {get;set;}
    // IT WILL NOT MAP
    // Property Names should match
    
        public PersonDTO Person {get;set;}
        
        }
    public class PersonDTO
    {
       public int PersonID {get;set;}
       public string Name {get;set;}
    
       public AddressDTO Address {get;set;}
       public CarDTO Car {get;set;}
    
    }
