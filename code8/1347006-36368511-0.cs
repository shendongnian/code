    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		var index = 0;
    		var myArray = new string[] {};
    		var isEmptyText = false;
    		do
    		{
    			Console.Write("Give me some input or press enter to quit: ");
    			var result = Console.ReadLine();
    			isEmptyText = string.IsNullOrWhiteSpace(result);
    			if (!isEmptyText) 
    			{
    				if (myArray.Length <= index) 
    				{
    					Array.Resize(ref myArray, index+1);
    				}
    
    				myArray[index++] = result;
    			}
    		} while (!isEmptyText);
    		
    		Console.WriteLine(myArray.Length);
    		Console.WriteLine(string.Join(", ", myArray));
    	}
    }
