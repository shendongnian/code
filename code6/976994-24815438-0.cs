	public string GetXRandomCharacters(int x)
	{
		System.Text.StringBuilder sb = new System.Text.StringBuilder();
		var random = new Random();
		var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		for (int i = 0; i < stringChars.Length; i++)
		{
			sb.Append(chars[random.Next(chars.Length)]);
		}
		
		return sb;
	}
	public string InjectRandomWord(string str, string word)
	{
		var random = new Random();
		int start = random.Next(str.Length - word.Length);
		
		str.Remove(start, word.Length).Insert(start, word);
	}
