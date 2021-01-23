    public class HomeController : Controller
    {
      private readonly IMediator _mediator;
    
      public HomeController(IMediator mediator)
      {
        _mediator = mediator;
      }
      public IActionResult Index()
      {
        var pong = _mediator.Send(new Ping {Value = "Ping"});
        return View(pong);
      }
    }
