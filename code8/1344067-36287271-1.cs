    [Route("api/person")]
    public class PersonController : Controller
    {
        [HttpGet]
        public string GetById([FromQuery]int id)
        {
    
        }
    
        [HttpGet]
        public string GetByName([FromQuery]string firstName, [FromQuery]string lastName)
        {
    
        }
    
        [HttpGet]
        public string GetByNameAndAddress([FromQuery]string firstName, [FromQuery]string lastName, [FromQuery]string address)
        {
    
        }
    }
