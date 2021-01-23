    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var result = CreatedAtRoute(
                routeName: "SubscriberLink", 
                routeValues: new { id = Guid.NewGuid() },
                value: null);
            return result;
        }
        [HttpGet("{id}", Name = "SubscriberLink")]
        public IActionResult GetSubscriber(Guid id)
        {
            return Ok();
        }
    }
