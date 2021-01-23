    Schema:
    int ID
    int UserType
    nvarchar Details
    etc...
    
    Entity:
    public class User
    {
       public int ID {get;set;}
       public int UserType {get;set;}
       public string Email{get;set;}
       public string Password{get;set;}
       public string Details {get;set;}
    }
