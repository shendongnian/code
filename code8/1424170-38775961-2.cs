    public class HomeController : Controller
    {
        private readonly IViewRenderingService _viewRenderingService;
        public HomeController(IViewRenderingService viewRenderingService)
        {
            _viewRenderingService = viewRenderingService;
        }
        public IActionResult Index()
        {
            var result = _viewRenderingService.RenderPartialView(ControllerContext, "PartialViewName", model: null);
            // do something with the string
            return View();
        }
    }
