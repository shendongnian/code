    public async Task StoreAccessToken(ExternalLoginInfo loginInfo)
    {
        var user = await UserManager.FindAsync(loginInfo.Login);
        if (user != null)
        {
            var newClaim = loginInfo.ExternalIdentity.Claims.Select(c => new Claim(c.Type, c.Value)).FirstOrDefault(c => c.Type == "googletoken");
    
            if (newClaim != null)
            {
                var userClaims = await UserManager.GetClaimsAsync(user.Id);
                foreach (var userClaim in userClaims.Where(c => c.Value == newClaim.Value).ToList())
                    await UserManager.RemoveClaimAsync(user.Id, userClaim);
    
                await UserManager.AddClaimAsync(user.Id, newClaim);
            }
        }
    }
