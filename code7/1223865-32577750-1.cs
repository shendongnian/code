    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Test
    {
    	public static void Main()
    	{
    		var myList = new List<int>() { 2,-3,1,3,4,5,-2,-1,};
    		myList.Sort(Compare);
    		foreach(var item in myList){
    			Console.WriteLine(item);
    		}
    	}
    	
    	static int Compare(int x, int y)
        {
         if (x > 0 && y < 0)
         {
            return -1;
         }
    
         if (x < 0 && y > 0)
         {
            return 1;
         }
    
         if (x < 0 && y < 0)
         {
            return y.CompareTo(x);
         }
         return x.CompareTo(y);
        }
    }
