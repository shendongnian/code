    public class PersonService
    {
      public object Get(PersonRequest request)
      {
        return GuestController.Get(request.PersonId);
      }
      public object Get(GuestRequest request)
      {
        return GuestController.Get(request.PersonId);
      }
    }
