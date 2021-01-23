    [Route("api/[controller]")]
    public class SubscribersController : Controller
    {
        public IActionResult Index()
        {
            var subscriber = new
            {
                Id = Guid.NewGuid(),
                FirstName = "Shaun",
                LastName = "Luttin"
            };
            // overload with three arguments
            return CreatedAtRoute(
                routeName: "SubscriberLink",
                routeValues: new { id = subscriber.Id },
                value: subscriber);
        }
        [HttpGet("{id}", Name = "SubscriberLink")]
        public IActionResult GetSubscriber(Guid id)
        {
            var subscriber = new
            {
                Id = id,
                FirstName = "Shaun",
                LastName = "Luttin"
            };
            return new JsonResult(subscriber);
        }
    }
