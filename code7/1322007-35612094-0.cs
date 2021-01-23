    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace PalinDromes
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			List<string> words = new List<string> () { "anotherword","civic", "deified", "lemel", "pop" ,"noon"};
    
    			string shortest = "";
    			string longest = "";
    
    			foreach (string word in words) 
    			{
    				if (isPalindrome (word)) 
    				{
    					if (word.Length > longest.Length)
    						longest = word;
    					else if (shortest == "" || word.Length < shortest.Length)
    						shortest = word;
    				}
    			}
    
    			Console.WriteLine ("Shortest: {0}", shortest);
    			Console.WriteLine ("Longest: {0}", longest);
    		}
    
    		public static bool isPalindrome(string word)
    		{
    			string first = word.Substring (0, word.Length / 2);
    			string second = word.Substring ((int)Math.Ceiling ((double)word.Length / 2), word.Length / 2);
    
    			return first == ReverseString (second);
    		}
    
    		public static string ReverseString(string s)
    		{
    			char[] arr = s.ToCharArray();
    			Array.Reverse(arr);
    			return new string(arr);
    		}
    	}
    }
