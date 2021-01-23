    using System;
    					
    public class Program
    {
    	public static void Main()
    	{
    		Random rand = new Random();
    		double percentage = rand.NextDouble();
    	
    		string[] greetings = new[] { "Hi", "Hello", "Howdy!", "Hey" };
    		string[] smilies = new[] { ";)", ":)", "=)", ":-)" };
    	
    		// Get a greeting
    		string greet = greetings[rand.Next(0, greetings.Length)];
    	
    		// Generate the smiley index using the probablity percentage
    		int randomIndex = rand.Next(0, (int)(smilies.Length / percentage));
    	
    		// Get a smiley if the generated index is within the bound of the smilies array
    		string smile = randomIndex < smilies.Length ? smilies[randomIndex] : String.Empty;
    				
    		Console.WriteLine("{0} {1}", greet, smile);
    	}
    }
