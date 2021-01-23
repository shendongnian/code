    using UnityEngine;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    
    public static class RNGUtils
    {
    	static void SwapListElements<T>(IList<T> list, int firstIndex, int secondIndex)
    	{
    		T tmp = list[firstIndex];
    		list[firstIndex]=list[secondIndex];
    		list[secondIndex]=tmp;
    	}
    	public static IList<T> RandomShuffle<T>(this IEnumerable<T> enumerable)
    	{
    		List<T> res = enumerable.ToList ();
    		for (int i = 0; i < res.Count; ++i) 
    		{
    			SwapListElements (res,i,Random.Range(i,res.Count));
    		}
    		return res;
    	}
    }
