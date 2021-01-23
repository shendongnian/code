    [Route("api/[controller]")]
    [CustomExceptionFilter]
    public class ValuesController : Controller
    {
         // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new Exception("Suckers");
            return new string[] { "value1", "value2" };
        }
    }
