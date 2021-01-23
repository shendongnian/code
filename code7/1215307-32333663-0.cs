    public static bool  IsAllUpper(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                return false;
        }
        return true;
    }
	
	public static string GetString(String input)
	{
		var arr = input.Split(' ');
		var result = "";
		
		foreach(var item in arr)
		{
			if(IsAllUpper(item))
				result += ' ' + item;
			else
				result += ' ' + item.ToLower();
			
			
		}
		return result;
	}
	
	public static void Main()
	{
		String s1 = "Pippo, pluto. paperino";
		String s2 = "Pippo, PLUTO. paperino";
		String s3 = "PIPPO, PLUTO. PAPERINO";
		
		
		
		Console.WriteLine(GetString(s1));
		Console.WriteLine(GetString(s2));
		Console.WriteLine(GetString(s3));
		
		
	}
