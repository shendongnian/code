    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var someObj = new { FirstName = "Shaun", LastName = "Luttin" };
            var result = CreatedAtRoute(
                routeName: "SubscriberLink", 
                routeValues: new { id = Guid.NewGuid() },
                value: someObj);
            return result;
        }
        [HttpGet("{id}", Name = "SubscriberLink")]
        public IActionResult GetSubscriber(Guid id)
        {
            return Ok();
        }
    }
