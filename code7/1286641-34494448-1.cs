	public async Task<bool> SearchNameAsync(string Name)
	{
		Group retrievedGroup = new Group();
		string foundGroup = await Client().Groups
				.Where(group => group.DisplayName.Equals(Name))
				.ExecuteAsync();
		return foundGroup == "Some Name";
	}
	
	
