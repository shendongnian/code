    // /api/people/{Id}/
    public class PersonRequest
    {
       public int PersonId {get; set;}
    }
    
    //  /api/people/{Id}/guest
    public class GuestRequest : PersonRequest
    {
        
    }
 
