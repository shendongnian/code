	public ActionResult Index()
	{
		BlogContext dbContext = new BlogContext();
		dbContext.Posts.Include(a => a.Tags);
		return View(dbContext.Posts.ToList());
	}
