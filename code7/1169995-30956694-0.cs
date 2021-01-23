    using System;
    using System.Collections.Generic;
    
    public class Program
    {
    	public static void Main()
    	{
    		string functionHeader = "public static void MyFunction(string Param1, int Param2, List<string> Param3)";
    		string parameters = functionHeader.Substring(functionHeader.IndexOf("(") + 1)
    			                              .Replace(", ", ",")
    										  .Replace(")", String.Empty);
    		
    		List<string> parametersCollection = new List<string>(parameters.Split(','));
    		parametersCollection.ForEach(pc => Console.WriteLine(pc));
    	}
    }
