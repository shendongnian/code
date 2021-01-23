    using System;
    using System.Linq;
    using System.Collections.Generic;
    					
    public class Program
    {
        public static void Main()
        {
            int[] a = new []{1,2,3};
            int[] b = new []{1,2,2,3};
            Dictionary<int, int> aDictionary = a.ToDictionary(i=>i, i => 0);
    	
            foreach(int i in b)
            {
                if(aDictionary.ContainsKey(i))
                {
                    aDictionary[i]++;
                }
            }
    	
            foreach(KeyValuePair<int, int> kvp in aDictionary)
            {
                Console.WriteLine(kvp.Key + ":" + kvp.Value);
            }
        }
    }
