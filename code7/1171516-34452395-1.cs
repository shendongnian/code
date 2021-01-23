    [RoutePrefix("api/user/home")]
    public class UserHomeController : ApiController
    {
         [Route]
         public string Get()
         {
           return "Test user GET";
         }
    }
