    using System;
    using System.Collections.Generic;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Console.WriteLine("YourQuestion() returns " + YourQuestion());
    		Console.WriteLine("AnswerOne() returns " + AnswerOne());
    		Console.WriteLine("AnswerTwo() returns " + AnswerTwo());
    	}
    	
    	private static bool condition1()
    	{
    		return false;
    	}
    	
    	private static bool condition2()
    	{
    		return true;
    	}
    	
    	private static bool condition3()
    	{
    		return true;
    	}
    	
    	
    	public static string YourQuestion() 
    	{
    		var thereIsAProblem = false;
    		var problemDescription = "";		
    		
    		if (condition1()) {
    			thereIsAProblem = true;
    			problemDescription = "x";
    		}
    		
    		if (!thereIsAProblem && condition2()) {
    			thereIsAProblem = true;
    			problemDescription = "y";
    		}
    		
    		return problemDescription;
    	}
    	
    	public static string AnswerOne() 
    	{
    		return checkCondition1() ??
    			   checkCondition2() ??
    			   checkCondition3();
    	}	
    	
    	private static string checkCondition1()
    	{		
    		return condition1() ? "x" : null;		
    	}
    	
    	private static string checkCondition2()
    	{		
    		return condition2() ? "y" : null;
    	}
    	
    	private static string checkCondition3()
    	{		
    		return condition3() ? "z" : null;			
    	}
    	
    	
    	public static string AnswerTwo()
    	{		
    		var conditionChecks = new Dictionary<string,Func<bool>>();
    		conditionChecks.Add("x",condition1);
    		conditionChecks.Add("y",condition2);
    		conditionChecks.Add("z",condition3);
    		foreach (var check in conditionChecks)
    		{			
    			if (check.Value())
    			{
    				return check.Key;
    			}
    		}
    		return null;
    	}
    	
    }
