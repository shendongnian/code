    using System.Collections.Generic;
    using System;
    public static class ListExtension {
    
    	public static T Random<T>(this List<T> list) {
    		if (list.Count < 1) {
    			throw new ArgumentOutOfRangeException ("List too short");
    		}
    		Random r = new Random ();
    		int randomIndex = r.Next (list.Count);
    		T t = list [randomIndex];
    		return t;
    	}
    }
