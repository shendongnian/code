    [Route("api/[controller]")]
    public class PersonController : Controller
    {
        public string Get([FromQuery]int id)
        {
    
        }
    
        public string Get([FromQuery]string firstName, [FromQuery]string lastName)
        {
    
        }
    
        public string Get([FromQuery]string firstName, [FromQuery]string lastName, [FromQuery]string address)
        {
    
        }
    }
