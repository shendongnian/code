    public ActionResult Index(string searchString)
    {
        var posts = from s in _context.Posts
                       select s;
    
        var postIndexViewModel = new PostIndexViewModel();
    
        if (!String.IsNullOrEmpty(searchString))
        {
            var terms = searchString.Trim().Split(' ');
            posts = posts.Where(s => terms.Any(terms.Contains));
         }
    
        // More code here
    
        return View(postIndexViewModel);
    
    }
