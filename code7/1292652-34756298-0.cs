    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            await Task.Delay(1000);
            return new string[] { "value1", "value2" };
        }
    }
