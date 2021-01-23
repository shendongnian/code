    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [Route("[action]/{name}")]
        public string GetSomething(string name)
        {
            return foo;
        }
    }
