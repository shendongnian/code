    public ActionResult Index()
    {
        var posts = db.Posts.Where(p => p.BlogUserEmail == User.Identity.Name)
                            .Include(p => p.BlogUser)
                            .Include(p => p.Category)
                            .Select(vm => new PortfolioVM(){
                                Id = vm.Id,
                                UrlSlug = vm.UrlSlug,
                                Picture = Convert.ToBase64String(vm.Picture),
                                ShortDescription = vm.ShortDescprition
                             }) ;
        
        return View(posts);
    }
