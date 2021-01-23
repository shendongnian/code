	public class BlogsController : Controller
	{
		public BlogsController(IBlogRepository repository)
		{
			this.repository = repository;
		}
		private IBlogRepository repository;
		public ActionResult Edit(int id)
		{
			Blog blog = repository.Find(id);
			if (blog == null)
				return HttpNotFound();
			BlogForm viewModel = new BlogForm(blog);
			return View(viewModel);
		}
	}
