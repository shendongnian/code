    public async Task<IdentityResult> CreateUserAsync(string email, string password, string groupId)
    {
        var user = new ApplicationUser
            {
                Id = userId,
                UserName = email
            };
            
        var userCreateResult = await _UserManager.CreateAsync(user, password);
        if(!userCreateResult.IsSuccess)
        {
            // user creation have failed - need to stop the transaction
            return userCreateResult;
        }
        
        // better to have a class with constants representing your claim types
        var groupIdClaim = new Claim("MyApplication:GroupClaim", ObjectId.GenerateNewId(DateTime.UtcNow).ToString());
        
        // this will save the claim into the database. Next time user logs in, it will be added to Principal.Identity
        var claimAddingResult = await _UserManager.AddClaimAsync(userId, groupIdClaim);
        return claimAddingResult;
    }
