    using System;
    using System.Linq;
    
    public class Test
    {
    	public static void Main()
    	{
    		Console.WriteLine("Please enter a three or fewer word phrase.");
            
            string s; 
    
            while ((s = Console.ReadLine()).Count(char.IsWhiteSpace) > 2)
                Console.WriteLine("You entered more than three words! Try again!");
    
            Console.WriteLine("You gave the phrase: {0}", s);
    	}
    }
