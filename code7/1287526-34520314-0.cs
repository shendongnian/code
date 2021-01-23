    [RoutePrefix("api/platypus")]
    public class PlatypusController: ApiController
    {
         [Route("{unit}/{begindate}")]
         [HttpPost]
         public void Post(string unit, string begindate)
         {
             int i = 2; 
         }
    }
