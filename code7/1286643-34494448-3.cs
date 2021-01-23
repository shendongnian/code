	public async Task<bool> SearchNameAsync(string Name)
	{
		Group retrievedGroup = new Group();
		List<string> foundGroup = await Client().Groups
									.Where(group => group.DisplayName.Equals(Name))
									.ExecuteAsync();
		return foundGroup.Contains("Some Name", StringComparer.OrdinalIgnoreCase);
	}
	
	
