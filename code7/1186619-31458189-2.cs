    public class RestController : ApiController
    {
        protected new OkResult Ok()
        {
            return Ok(null);
        }
    
        protected OkResult Ok(string message)
        {
            // Do your thing...
        }
    }
