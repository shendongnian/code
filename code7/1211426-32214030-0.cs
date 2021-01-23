    using System;
    using System.Collections.Generic;
    using System.Linq;
    					
    public class Program
    {
    	class Part
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    	
    	public static void Main()
    	{
    		{
                var L1 = new List<int> { 1, 2, 3, 4, 5, 6 };
                var L2 = new List<int> { 4, 3 };
    
                bool t = L2.All(l2 => L1.Contains(l2));
    			
    			Console.WriteLine("L1 contains L2: {0}", t);
            }
    
            {
                var L1 = new List<Part> { new Part { id = 1 }, new Part { id = 2 }, new Part { id = 3 }, new Part { id = 4 } };
                var L2 = new List<Part> { new Part { id = 3 }, new Part { id = 4 } };
    
                bool u = L2.All(l2 => L1.Any(l1 => l1.id == l2.id));
    			
    			Console.WriteLine("L1 contains L2: {0}", u);
            }
    	}
    }
