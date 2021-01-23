    public PartialViewResult Search(string query)
        {
            var result = db.Users.Where(u => u.UserName.ToLower().Contains(query.ToLower())).ToList();
    
            return PartialView("_UsersResult", result);
        }
