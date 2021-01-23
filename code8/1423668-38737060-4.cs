    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    public class Test
    {
    	public static void Main(String[] args)
        {
            int k = Int32.Parse(Console.ReadLine().Split(' ')[1]);
            var S = Array.ConvertAll(Console.ReadLine().Split(' '), Int32.Parse);
    		List<HashSet<int>> cnt = new List<HashSet<int>>();
            // first get all pairs in S whose sum doesn't divide k, 
            // each pair in their own subset set of S
            cnt = (from i in S
                          from j in S
                          where i < j && ((i + j) % k != 0)
                          select new HashSet<int>() { i, j }).ToList();
            // for each subset, for each number in the original set 
            // not already in the subset, if the number summed with
            // every numer in the subset doesn't divide k, add the
            // number to the subset
            
            foreach(var ss in cnt){
                 foreach(int n in S.Where(q => !ss.Contains(q)))
                    if(ss.All(m => (m + n) % k != 0)){
                       ss.Add(n);
                    }
            }
                    
            // get the size of the largest subset, print to console
            int max = cnt.Max(ss => ss.Count);
            Console.WriteLine(max);
        }
    }
