    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication13
    {
    	class Program
    	{
    		static void Main(string[] args)
    		{
    			var output = FindTwoSum(new List<int>() { 1, 3, 5, 7, 9 }, 12);
    			foreach (var x in output)
    				Console.WriteLine(x.Item1 + " " + x.Item2);
    
    			Console.ReadKey(true);
    		}
    
    		public static IEnumerable<Tuple<int, int>> FindTwoSum(List<int> list, int sum)
    		{
    			List<Tuple<int, int>> ListOfInt = new List<Tuple<int, int>>();
    			for (int i = 0; i < list.Count; i++)
    			{
    				for (int j = 0; j < list.Count; j++)
    				{
    					if (list[i] + list[j] == sum)
    					{
    						ListOfInt.Add(new Tuple<int, int>(i, j));
    					}
    				}
    			}
    
    			foreach (var elemt in ListOfInt)
    			{
    				yield return elemt;
    			}
    
    		}
    	}
    }
