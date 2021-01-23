    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        [Route("[action]/{id:string}")]
        public string GetSomething(string id)
        {
            return foo;
        }
    }
