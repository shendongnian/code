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
    			return word == ReverseString (word);
    		}
    
    		public static string ReverseString(string s)
    		{
    			char[] arr = s.ToCharArray();
    			Array.Reverse(arr);
    			return new string(arr);
    		}
    	}
    }
