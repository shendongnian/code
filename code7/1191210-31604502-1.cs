    public class EatController : ApiController 
    {
       [HttpPost]
       public HttpResponseMessage Post(List<toEat> list)     
       {
            return Ok();
       }       
    }
