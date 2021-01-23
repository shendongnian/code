    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine(IsPalindrome("TEST"));
    		Console.WriteLine(IsPalindrome("TESTSET"));
    	}
    	
    	public static bool IsPalindrome(string value)
    	{
        	if ( value == null )
            	return false;
    
    	    if ( value.Length == 0 )
        	    return true;
    
    		int startChar = 0;
    		int endChar = value.Length - 1;
    		while(value[startChar] == value[endChar] && startChar < endChar)
    		{
    			startChar++;
    			endChar--;
    			if(startChar >= endChar) return true;
    		}
    	    return false;
    	}
    }
