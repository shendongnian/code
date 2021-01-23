	public class CategoryController : Controller
	{
		private DbOnlineIS db = new DbOnlineIS();
		public ActionResult Index() {
			var categoryViewModel = new CategoryViewModel();
			categoryViewModel.Categories = db.Categories.ToList();
			categoryViewModel.Category = new Category();
			return View(categoryViewModel);
		}
		
		// rest of the actions
	}
