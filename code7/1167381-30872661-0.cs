    static class MyExtensions 
    {
	     public static bool AnyOrMinusOne(this IEnumerable<string> list, string term) 
         {
    		return term == "-1" || list.Any(x => x == term);
	     }
    }
