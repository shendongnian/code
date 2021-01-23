    public static class Iterator
    {
       public static IEnumerable<object[]> Enumerate(params IEnumerable[] enumerables)
       {
         var list = new List<object>();
    	 var enumerators = new List<IEnumerator>();
    	 bool end = false;
    	   
         foreach(var enu in enumerables)
    	 {
           enumerators.Add(enu.GetEnumerator());
    	 }
         while(!end)
         {
    	   list.Clear();
           foreach(var enu in enumerators)
    	   {
    		   if(!enu.MoveNext()) { end = true; break; }
    		   list.Add(enu.Current);		   		   
    	   }
    	   if(!end) yield return list.ToArray();		   
         }
       }
    }
