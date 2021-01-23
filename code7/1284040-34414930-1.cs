    [Authorize(Roles = "RegisteredUsers")]
    public ActionResult Index(string searchString)
    {   
        if (!String.IsNullOrEmpty(searchString))
        {
            return View(db.Users.Where(s => s.User.LastName.Contains(searchString)).ToList);
        }
        return View(new List<User>());
    }
