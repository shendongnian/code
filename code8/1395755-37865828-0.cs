	public void Main()
    {
		string input = "123.45.678.90:00000/98765432109876541/[CLAN]PlayerName joined [windows/12345678901234567]";
		
		var content = input.Split('/');
		
		var ip = content[0];
		var groupId = content[1];
		var groupName = CleanName(content[2]);
		var groupId1 = RemoveLast(content[3]);
		
		Console.WriteLine(groupName); // or whatever
    }
	
	private static string CleanName(string name)
	{
		return name.Replace(" [windows", String.Empty); // is it a constant?
	}
	
	private static string RemoveLast(string s)
	{
		return s.Remove(s.Length - 1); // to remove the trailing ']'
	}
