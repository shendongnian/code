	public class CategoryController : Controller
	{
		private DbOnlineIS db = new DbOnlineIS();
		public ActionResult Index() {
			var categoryViewModel = new CategoryViewModel();
			categoryViewModel.Categories = db.Categories.ToList();
			categoryViewModel.Category = new Category();
			return View(categoryViewModel); // list + create category
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(Category category) // call this action to create category.
		{
			if (ModelState.IsValid)
			{
				category.date_created = DateTime.Now;
				category.date_updated = DateTime.Now;
				db.Categories.Add(category);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(category);
		}
	}
