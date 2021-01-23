	public static class CharExtensions
	{
		public static bool IsLetterOrDigit(this char c, params char[] specialCharacters)
		{
			return char.IsLetterOrDigit(c) || specialCharacters.Any(x => c.Equals(x));
		}
	}
	
