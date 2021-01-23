    using System;
    using System.Linq;
    
    public class Program
    {
    	public static void Main()
    	{
    		Console.Write("Enter number of columns: ");
    		int userinput = Convert.ToInt16(Console.ReadLine());
    		int[] columns = new int[userinput];
    		
    		Random Dice = new Random();
    		bool search = true;
    		
    		DateTime start = DateTime.Now;
    		while (search)
    		{
    			for (int i = 0; i < columns.Length; i++)
    			{
    				columns[i] = Dice.Next(1, 7);
    			}
    			
    			if (columns.Distinct().Count() == 1)
    			{
    				Console.WriteLine("All columns match with the value of {0}", columns[0]);
    				Console.WriteLine("It took {0} to get all columns to match", DateTime.Now.Subtract(start));
    				search = false;
    			}
    		}
    	}
    }
