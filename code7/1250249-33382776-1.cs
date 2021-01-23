    #define UNCONDITIONAL
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    
    namespace StackOverflow
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			HashSet<int> hash = new HashSet<int>();
    			Random rnd = new Random();
    
    #if(UNCONDITIONAL)
    			Console.WriteLine("Adding unconditionally...");
    #else
    			Console.WriteLine("Adding after checks...");
    #endif
    
    			while(hash.Count < 5)
    			{
    				int rv = rnd.Next (1, 11);
    #if(UNCONDITIONAL)
    				hash.Add (rv);
    #else
    				if(hash.Contains(rv))
    				{
    					Console.WriteLine ("Duplicate skipped");
    				}
    				else
    				{
    					hash.Add (rv);
    				}
    #endif
    			}
    
    			List<int> list = hash.ToList ();  // ToList() gives back a new instance
    			foreach(var e in list)
    			{
    				Console.WriteLine (e);
    			}
    		}
    	}
    }
