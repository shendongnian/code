    [RoutePrefix("api/Document")]
    public class DocumentController : ApiController
    {    
        [Route("{id:int}")]
        [HttpGet]
        public String GetById(int id)   // The name of this function can be anything now
        {
            return "test";
        }
    
        [Route("{name}"]
        [HttpGet]
        public String GetByName(string name)
        {
            return "test2";
        }
    }
