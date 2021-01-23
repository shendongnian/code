	public virtual async Task<bool> SendTwoFactorCodeAsync(string provider)
	{
		var userId = await GetVerifiedUserIdAsync().WithCurrentCulture();
		if (userId == null)
		{
			return false;
		}
		var token = await UserManager.GenerateTwoFactorTokenAsync(userId, provider).WithCurrentCulture();
		// See IdentityConfig.cs to plug in Email/SMS services to actually send the code
		await UserManager.NotifyTwoFactorTokenAsync(userId, provider, token).WithCurrentCulture();
		return true;
	}
