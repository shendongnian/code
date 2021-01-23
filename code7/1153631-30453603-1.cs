    using (var _db = new ApplicationDbContext())
    {
        UserStore<DALApplicationUser> UserStore = new UserStore<DALApplicationUser>(_db);
        UserManager<DALApplicationUser> UserManager = new UserManager<DALApplicationUser>(UserStore);
        UserManager.UserLockoutEnabledByDefault = true;
        DALApplicationUser user = _userService.GetUserByProfileId(id);
        
    	bool a = UserManager.IsLockedOut(user.Id);
    	
    	//user.LockoutEndDateUtc = DateTime.MaxValue; //.NET 4.5+
    	user.LockoutEndDateUtc = new DateTime(9999, 12, 30);
        _db.SaveChanges();
    
        a = UserManager.IsLockedOut(user.Id);
    }
