    using System;
    using System.Text.RegularExpressions;
    
    public class Test
    {
    	public static void Main()
    	{
    		string[] fail = {"ABCDacbd", "ACDE", "ABCDE\n", "_01234", "ABCDÉ", "ABCD́Ē", "ABCDEF_", "A_B_CDEF", "AB_C", "1234567890123456789012345", "123456_789012345678901234"};
    		string[] ok = {"ACBDEF", "01234", "ABC_DE1", "123456789012345678901234", "12345_789012345678901234"};
    		
    		foreach (string s in fail) {
    			Console.WriteLine(s + " " + Validate(s));
    		}
    		Console.WriteLine();
    		
    		foreach (string s in ok) {
    			Console.WriteLine(s + " " + Validate(s));
    		}
    	}
    	
    	private static bool Validate(string str) {
    		if (str.Length < 5 || str.Length > 24) {
    			return false;
    		}
    		
    		return Regex.IsMatch(str, @"^[A-Z0-9]+(?:_[A-Z0-9]+)?\z");
    	}
    }
