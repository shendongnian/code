    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<int> Get(Request request)
        {
            return request.categoryIds;
        }
    }
