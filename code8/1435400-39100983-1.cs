	public ActionResult Posts()
	{
		var posts = _yourDbContext.Posts.Include(x => x.Images).ToList();
		
		return View(posts);
	}
