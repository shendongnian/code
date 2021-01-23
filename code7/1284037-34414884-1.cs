    IQueryable<User> users = db.Users;
    
    if (!String.IsNullOrEmpty(searchString))
    {
        users = users.Where(s => s.User.LastName.Contains(searchString));
    }
    
    return View(users.ToList());
