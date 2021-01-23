    using System;
    using System.Linq;
    using System.Collections.Generic;
					
    public class Program
    {
	    public static void Main()
	    {
		    var array = new int[]{ 4,1,5,4,3,1,6,5 };
		    RemoveRepeated(ref array);
		
		    foreach (var item in array)
		    	Console.WriteLine(item);
	    }
	    static void RemoveRepeated(ref int[] array)
        {
            array = new HashSet<int>(array).ToArray();
        }
    }
