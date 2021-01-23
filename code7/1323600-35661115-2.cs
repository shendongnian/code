	public ActionResult Index()
	{
		BlogContext dbContext = new BlogContext();
		var model = dbContext.Posts.Include(a => a.Tags).ToList();
		return View(model);
	}
