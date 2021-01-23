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
        // GET api/Issues/special/5
        [HttpGet("special/{id}")]
        public string GetSpecial(int id)
        {
            return "special request for "+id;
        }
        // GET another/5
        [HttpGet("~/another/{id}")]
        public string AnotherOne(int id)
        {
            return "request for AnotherOne method with id:" + id;
        }
        // GET api/special2/5
        [HttpGet()]
        [Route("~/api/special2/{id}")]
        public string GetSpecial2(int id)
        {
            return "request for GetSpecial2 method with id:" + id;
        }
    }
