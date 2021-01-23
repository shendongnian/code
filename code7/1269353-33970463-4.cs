    public static bool IsPalindrome(string value)
    {
        if ( value == null )
            return false;
    
        if ( value.Length <= 1 )
            return true;
    
    	if ( value[0] != value[value.Length - 1] )
            return false;
    		
        return IsPalindrome(value.Substring(1,value.Length - 2));
    }
