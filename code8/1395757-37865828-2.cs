	public void Main()
    {
		string input = "123.45.678.90:00000/98765432109876541/[CLAN]Player/Na/me joined [windows/12345678901234567]";
		
		// we want "123.45.678.90:00000/98765432109876541/[CLAN]Player/Na/me joined" and "12345678901234567]"
		var content = input.Split(new string[]{" [windows/"}, StringSplitOptions.None);
        // we want ip + groupId + everything else
		var tab = content[0].Split('/');
		
		var ip = tab[0];
		var groupId = tab[1];
		var groupName = String.Join("/", tab.Skip(2)); // merge everything else. We use Linq to skip ip and groupId
		var groupId1 = RemoveLast(content[1]); // cut the trailing ']'
		
		Console.WriteLine(groupName);
    }
	private static string RemoveLast(string s)
	{
		return s.Remove(s.Length - 1);
	}
