     private int? Greater(int? a, int? b)
     {
       if(a.HasValue && b.HasValue)
       {
        return a > b ? a : b;
       }
       if(a.HasValue)
         return a;
       if(b.HasValue)
         return b;
       return null;
    }
