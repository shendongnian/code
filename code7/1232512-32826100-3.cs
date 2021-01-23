    public ActionResult BannedUsers()
    {
       var bannedUsers = 
    		db.Users
    		.Where(d => d.IsBanned)
    		.Join(
    			db.Users,
    			bannee => bannee.BannedBy,
    			banner => banner.UserId,
    			(bannee, banner) => new BannedUser() 
                    { 
                        BannedByUserName = banner.UserName,
                        BannedUser = bannee 
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
    	public IEnumerable<BannedUser> BannedUsers { get; set; }
    }
    
    public class BannedUser
    {
    	public ApplicationUser BannedUser { get; set; } 
        public string BannedByUserName { get; set; }
    }
