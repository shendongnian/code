    var result = new List<Profile>();
    
    using (AppDbContext ctx = new AppDbContext())
    {
    	var rolesForUser = userManager.GetRoles(UserId);
    	if(rolesForUser.Count() <= 0)
    	{
    		return View("SetupNewProfile");
    	}
        	
		var bandProfile = ctx.BandProfiles.Where(u => u.UserId == UserId)
										  .Select(x => new Profile() { Id = x.Id, Name = x.Name})
										  .ToList();
		var musicanProfile = ctx.MusicanProfiles.Where(u => u.UserId == UserId)
										  .Select(x => new Profile() { Id = x.Id, Name = x.Name})
										  .ToList();
		var regularProfile = ctx.RegularProfile.Where(u => u.UserId == UserId)
										  .Select(x => new Profile() { Id = x.Id, Name = x.Name})
										  .ToList();
	 
	 
    	result.AddRange(BandProfile);
    	result.AddRange(MusicanProfile);
    	result.AddRange(RegularProfile);	
    }
    
    return View(result);
