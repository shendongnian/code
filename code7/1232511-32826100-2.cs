    public ActionResult BannedUsers()
    {
       var bannedUsers = 
    		db.Users
    		.Where(d => d.IsBanned)
    		.Join(
    			db.Users,
    			bannee => bannee.BannedBy,
    			banner => banner.UserId,
    			(bannee, banner) => new { BannedByUserName = bannee.UserName, BannedByUserId = banner.UserId, BannedUser = bannee })
    		.GroupBy(x => new { x.BannedByUserName, x.BannedByUserId })
    		.Select(x => new BannedUserCollection()
    			{
    				BannedByUserName = x.Key.BannedByUserName,
    				BannedUsers = x
    			})
    		.AsEnumerable();
    		
       var model = new BannedUsersViewModel
       {
           BannedUsers = bannedUsers
       };
    
       return View(model);
    }
    
    public class BannedUsersViewModel
    {
    	public IEnumerable<BannedUsersCollection> { get; set; }
    }
    
    public class BannedUsersCollection
    {
    	public IEnumerable<ApplicationUser> BannedUsers { get; set; } 
        public string BannedByUserName { get; set; }
    }
