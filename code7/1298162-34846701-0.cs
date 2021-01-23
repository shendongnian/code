    [Route("api/[controller]")]
    public class IssuesController : Controller
    {
        // GET: api/Issues
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "item 1", "item 2" };
        }
        // GET api/Issues/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "request for "+ id;
        }
        // GET api/special/5
        [HttpGet("special/{id}")]
        public string GetSpecial(int id)
        {
            return "special request for"+id;
        }
    }
