    using System;
    using System.Linq;
     
    public class Test
    {
    	public static void Main()
    	{
            // Create sequence of integers from 0 to 10
    		var sequence = Enumerable.Range(0, 10).Where(p => 
            { 
                // In each 'where' clause, print the current item.
                // This shows us when the clause is executed
                Console.WriteLine(p); 
                // Make sure every value is selected
                return true;
            });
     
    		foreach(var item in sequence)
    		{
                // Print a marker to show us when the loop body is executing.
                // This helps us see if the 'where' clauses are evaluated 
                // before the loop starts or during the loop
    			Console.WriteLine("Loop body exectuting.");
    		}
    	}
    }
