	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			var model = new SampleViewModel();
			
			
			return View(model);
		}
		
		[HttpPost]
		public ActionResult Index(SampleViewModel model)
		{
			// model.Property1 is accessable here
			// as well as model.Property2
			
            // but if you want something not in the view model, use Request.Form
			ViewData["CustomProperty"] = Request.Form["CustomProperty"];
			return View(model);
		}
	}
