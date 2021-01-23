    public ActionResult BannedUsers()
    {
       var bannedUsers = 
    		db.Users
    		.Where(d => d.IsBanned)
    		.Join(
    			db.Users,
    			bannee => bannee.BannedBy,
    			banner => banner.UserId,
    			(bannee, banner) => new { BannedByUserName = banner.UserName, BannedByUserId = banner.UserId, BannedUser = bannee })
    		.GroupBy(x => new { x.BannedByUserName, x.BannedByUserId })
            .ToArray();
    
       var model = new BannedUsersViewModel
       {
           BannedUsers = bannedUsers
       };
    
       return View(model);
    }
