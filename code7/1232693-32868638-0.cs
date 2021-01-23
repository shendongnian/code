    using System;
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    public class Test
    {
    	public static void Main()
    	{
    		var lists = new List<List<int>>
    		{
    			new List<int> { 1, 2, 3 }, // 6
    			new List<int> { 3 }, // 3
    			new List<int> { 3, 3 }, // 6
    			new List<int> { 1, 2 }, // 3
    			new List<int> { 6 } // 6
    		};
    		
    		Console.WriteLine(lists.GetSumList(6).Count); // 3
    	}
    }
    
    public static class ListHelpers
    {
    	public static List<List<int>> GetSumList(this List<List<int>> list, int sum)
    	{
    		return list.Where(x => x.Sum() == sum).ToList();
    	}
    }
