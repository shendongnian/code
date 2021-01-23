    using System;
    using System.Collections.Generic;
					
    public class Program
    {
	    public static void Main()
	    {
		 int result = 1;
		 List<int> lst = new List<int>();
		 lst.Add(1);
		 lst.Add(2);
		 lst.Add(3);
	     lst.Add(18);
		 lst.Add(4);
		 lst.Add(1000);
		 lst.Add(-1);
		 lst.Add(-1000);
		
		 lst.Sort();
		
		 foreach(int curVal in lst)
		 {
			if(curVal <=0)
				result=1;
			else if(!lst.Contains(curVal+1))
			{
				result = curVal + 1 ;
			}
			
			Console.WriteLine(result);
		 }
	    }
    }
