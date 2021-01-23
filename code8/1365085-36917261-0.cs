    public async Task<bool> AddClaim(string type, string value)
        {
            var username = User.GetUserName();
            var user = await _userManager.FindByNameAsync(username);
            Claim claimToAdd = new Claim(type, value);
            var result = await _userManager.AddClaimAsync(user, claimToAdd);
            return result.Succeeded;
            
        }
