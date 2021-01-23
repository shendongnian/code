    // /api/guest/{Id}
    public class GuestRequest : PersonRequest
    {
       public int GuestId {get; set;}
    }
    
    //  /api/people/{Id}
    public class PersonRequest 
    {
       public int PersonId {get; set;}
    }
    
    
    public class GuestService 
    {
      public object Get(GuestRequest request)
      {
        return GuestController.Get(request.GuestId);
      }
    }
    
    public class PersonService 
    {
      public object Get(PersonRequest request)
      {
        return PersonController.Get(request.PersonId);
      }
    }
    
    public class GuestController : PersonController
    {
       public object Get(Int Id)
       {
          // get the Guest by Id
       }
    }
    
    public class PersonController 
    { 
       public object Get(Int Id)
       {
          // get the Person by Id
       }
    }
