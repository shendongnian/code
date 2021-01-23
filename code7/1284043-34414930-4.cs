    [Authorize(Roles = "RegisteredUsers")]
    public ActionResult Index(string searchString)
    {   
        var query = db.Users;
        if (!String.IsNullOrEmpty(searchString))
        {
            query = db.Users.Where(s => s.User.LastName.Contains(searchString));
        }
        //additional filtering can be applied to `query`
        return View(query.ToList());    
    }
