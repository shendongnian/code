	private async Task UpdateUserGameState(int gameState, string userId)
	{
		var user = await UserManager.FindByIdAsync(userId);
		// ...
		// add missing await
		await UserManager.UpdateAsync(user);
	}
