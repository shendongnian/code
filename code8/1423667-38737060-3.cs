    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class Test
    {
    	public static void Main(String[] args)
        {
            ...
           foreach(var ss in cnt){
                 foreach(int n in S.Where(q => !ss.Contains(q)))
                    if(ss.All(m => (m + n) % k != 0)){
                       ss.Add(n);
                    }
              // Log here, you will see the size is updated to 3
                Console.WriteLine(ss.Count);
            }
            // Log here, it is still printing 2 !         
    		foreach(var ss in cnt)
                 Console.WriteLine(ss.Count);
            // get the size of the largest subset, print to console
            int max = ...
            Console.WriteLine(max);
        }
    }
