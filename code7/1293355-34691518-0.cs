    [TestCase("Ruskin", "rusk")] // will fail test
	[TestCase("Ruskin", "skin")] // will fail test
	[TestCase("Ruskin", "Ruski")] // will fail test
	[TestCase("Ruskin", "Ruskin")] // will fail test
	[TestCase("John Yan", "HnYa@123")] // will fail test
	[TestCase("Ruskin", "bob")] // will pass test
	[TestCase("Ruskin", "ru5k")] // will pass test
	[TestCase("Ruskin", "niks")] // will pass test
	public void Password_Contain_4_Successive_Characters_Of_User_FullName(string userName, string password)
	{
		var groupsOfFour = new List<string>();
		// do checks to make sure password/username are at least 4 characters etc
		string userNameWithoutSpaces = userName.Replace(" ", "");
		for (int i = 0; i < userNameWithoutSpaces.Length; i++)
		{
			groupsOfFour.Add(userNameWithoutSpaces.Substring(i, 4));
			if (i + 4 >= userNameWithoutSpaces.Length)
				break;
		}
		Assert.IsEmpty(groupsOfFour.Where(s => password.IndexOf(s, StringComparison.InvariantCultureIgnoreCase) > -1));
	}
