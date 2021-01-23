    using System;  				
    using System.Text.RegularExpressions;
    
    public class Program
    {
    	public static void Main()
    	{
          string input = "Some123Grouping";
          string pattern = @"([A-Za-z]+)(\d+)([A-Za-z]+)";
    		
          Regex rx = new Regex(pattern);
          var match = rx.Match(input);
    
          Console.WriteLine("{0} matches found in:\n   {1}", 
                              match.Groups.Count, 
                              input);
          var newInput = "";
          for(int i= match.Groups.Count;i>0;i--){
            newInput +=  match.Groups[i];              
          }
          Console.WriteLine(newInput);
    	}
    }
