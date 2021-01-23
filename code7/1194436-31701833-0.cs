    using System;
    using System.Collections.Generic;
    
    public class Test
    {
    	public static void Main()
    	{
    		var listM = new List<int>();
    		var listN = new List<int>();
    		for(int i = 0, x = 0; x < 50; i+=13, x++) { 
    			listM.Add(i);
    		}
    		for(int i = 0, x = 0; x < 10000; i+=7, x++) { 
    			listN.Add(i);
    		}
    		Console.WriteLine(SortedExcept(listM, listN).Count);
    	}
    	
    	public static List<T> SortedExcept<T>(List<T> m, List<T> n) {
    		var result = new List<T>();
    		foreach(var itm in m) {
    			var index = n.BinarySearch(itm);
    			if(index < 0) { 
    				result.Add(itm); 
    			}
    		}
    		return result;
    	}
    }
