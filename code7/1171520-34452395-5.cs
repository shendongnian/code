    [RoutePrefix("api/admin/home")]
    public class AdminHomeController : ApiController
    {
         [Route]
         public string Get()
         {
           return "Test admin GET";
         }
    }
