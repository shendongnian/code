    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		string url = "http://myurl.com/&&var=79";
    		string[] parameters = url.Split('&');
    		
    		//Method 1 - just to check existance of "&" character
    		if(parameters.Length > 0) Console.WriteLine("Character '&' present");
    		
    		//Method 2 - check if repeated occurence of "&" exists
    		bool isRepetedExistance = false;
    		foreach(string keyValuePair in parameters) {
    			if(keyValuePair.Length == 0) {
    				isRepetedExistance = true;
    				break;
    			}
    		}
    		Console.WriteLine(String.Format("Repeted existance of character '&' is {0}present", (isRepetedExistance ? "" : "not ")));
    	}
    }
