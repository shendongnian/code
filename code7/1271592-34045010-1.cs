     [Authorize(Roles="Admins")]
     public class SomeController : ApiController {
       [OverrideAuthorization]
        [Authorize(Roles="Users")]
       public IEnumerable<SomeModel> Get() {...}
       public SomeModel Post() {...}
      }
