	public ActionResult Index()
	{
		BlogContext dbContext = new BlogContext();
		dbContext.Posts.Include(a => a.Tags).ToList();
		return View(dbContext.Posts.ToList());
	}
