    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string text = "this is a ss and mm is not to be count an me"; //Input string
    		
    		// Find only 2 letter strings
    		List<string> allTwoLetters = text.Split(new Char[]{' '}).Where(x=>x.Length==2).ToList();
    		
    		
    		//Find all Distinct strings in two letter string list
    		List<string> distinctStrings = allTwoLetters.Distinct().ToList();
    		
    		//dictionary to hold result
    		Dictionary<string,int> letterCount = new Dictionary<string,int>();
    		
    		//Iterate throug each string in distinct string and count how many such strings are there i two letter list of strings
    		foreach(string current in distinctStrings)
    		{
    			letterCount.Add(current,allTwoLetters.Where(p=>p == current).ToList().Count);
    		}
    		
    		//Output values
    		foreach(var kvp in letterCount)
    		{
    			Console.WriteLine(kvp.Key + " - "+ kvp.Value);
    		}
    	}
    }
