    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace SumTheNumbers
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    
    			Console.WriteLine("Insert the numbers separated by a space or [Enter]> key, when finished write T and press [Enter] and you will have the result");
    			List<int> values = new List<int>();
    			while (true)
    			{
    				string inputData = Console.ReadLine();
    				if (inputData.ToUpper().StartsWith("T")) break;
    				string[] svals = inputData.Split(' ');
    				
    				for (int i = 0; i < svals.Length; i++)
    				{
    					int x = 0;
    					int.TryParse(svals[i], out x);
    					if (x != 0) values.Add(x);
    				}
    
    
    
    			}
    
    			//Traditional mode
    			int total = 0;
    			for (int i = 0; i < values.Count; i++)
    			{
    				total = total + values[i];
    			}
    
    			//Linq mode
    
    			int totalLinq = values.Sum();
    
    			Console.WriteLine("The sum is");
    			Console.Write("Total: ");
    			Console.WriteLine(total.ToString());
    			Console.Write("Total linq: ");
    			Console.WriteLine(totalLinq.ToString());
    			Console.WriteLine("Press a key to end...");
    			Console.ReadKey();
    
    		}
    	}
    }
