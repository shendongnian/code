    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return CreatedAtRoute("SubscriberLink", new { id = Guid.NewGuid() });
        }
        [HttpGet(Name = "SubscriberLink")]
        [Route("SubscriberLink")]
        public IActionResult GetSubscriber(Guid id)
        {
            return Ok();
        }
    }
