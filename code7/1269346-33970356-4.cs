	public static bool IsPalindrome(string value)
	{
        if ( value == null )
            return false;
		 return value == new String(value.ToCharArray().Reverse().ToArray());
    }
