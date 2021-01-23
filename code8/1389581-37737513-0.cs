    public ActionResult Index()
        {
            var userDetails = db.UserDetails.Include(u => u.User);
            return View(userDetails.ToList());
        }
