    private static readonly object Locker = new object();
    
    var currentUserName = User.Identity.Name;
    
    lock(Locker)
    {
    	var currentUser = await _userRepository.GetAsync(u => u.UserName == currentUserName);
    
    	// Create user that does not yet exist
    	if (currentUser != null) return HttpBadRequest();
    
    	var user = new User(currentUserName);
    
    	using(new CreatedBySystemProvider(_userRepository))
    	{
    		_userRepository.Add(user);
    		await _userRepository.SaveChangesAsync();
    		await user.AddRoleAsync(AppSumRoles.Authenticated);
    		/* Temporary add SysAdmin role */
    		if(string.Equals(currentUserName, @"BIJTJES\NilsG", StringComparison.CurrentCultureIgnoreCase))
    		{
    			using(new CreatedBySystemProvider(_userRoleRepository))
    			{
    				await user.AddRoleAsync(AppSumRoles.SysAdmin);
    			}
    		}
    		currentUser = await _userRepository.GetAsync(u => u.Id == user.Id);
    	}
    }
    
    return Ok(currentUser);
