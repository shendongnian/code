    public ActionResult Index()
    {
        var posts = db.Posts.Where(p => p.BlogUserEmail == User.Identity.Name).Include(p => p.BlogUser).Include(p => p.Category);
        
        // create collection
        List<string> ImageCollection = new List<string>();
        foreach (var item in posts)
        {
            //add images to list
            ImmageCollection.Add(Convert.ToBase64String(item.Picture));
        }
        //Add list to ViewBag
        ViewBag.ImageToShow = ImageCollection;
        return View(posts.ToList());
    }
