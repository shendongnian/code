    public ActionResult Index()
    {
    	var posts = db.Posts.Where(p => p.BlogUserEmail == User.Identity.Name).Include(p => p.BlogUser).Include(p => p.Category);
    	foreach (var item in posts)
    	{
    		byte[] buffer = item.Picture;
    		
    		// this is really wrong!
    		//ViewBag.ImageToShow = Convert.ToBase64String(buffer);
    		
    		// this is what you should do, or something like this
    		ViewBag.ImagesToShow = new List<String>();
    		ViewBag.ImagesToShow.Add(Convert.ToBase64String(buffer));
    	}
    	return View(posts.ToList());
    }
