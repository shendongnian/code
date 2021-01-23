    var result = new List<object>();
    
    using (AppDbContext ctx = new AppDbContext())
    {
    	var rolesForUser = userManager.GetRoles(UserId);
    	if(rolesForUser.Count() <= 0)
    	{
    		return View("SetupNewProfile");
    	}
        	
    	var bandProfile = ctx.BandProfiles.Where(u => u.UserId == UserId).ToList();
    	var musicanProfile = ctx.MusicanProfiles.Where(u => u.UserId == UserId).ToList();
    	var regularProfile = ctx.RegularProfiles.Where(u => u.UserId == UserId).ToList();
    	
    	result.AddRange(BandProfile);
    	result.AddRange(MusicanProfile);
    	result.AddRange(RegularProfile);	
    }
    
    return View(result);
