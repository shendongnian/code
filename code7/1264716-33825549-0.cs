    public class AgencyUser {
         public int Id {get;set;}
         public Agency Agency {get;set;}
         public User User {get;set;}
         public UserRole UserRole {get;set;}
    }
    
    public enum UserRole {
         Principal,
         Agent
    }
