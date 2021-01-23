    @if (array2.MoveNext())
    {
       @array2.Current[0], @array2.Current[1], @array2.Current[3]<br />
       var lastElement = array2.Current;
       while (array2.MoveNext())
       {
         if (array2.Current[0] != lastElement[0])
         {
           @array2.Current[0],
         }
         else if (array2.Current[1] != lastElement[0])
         {
           @array2.Current[1],
         }
         @array2.Current[2]
         lastElement = array2.Current;
       }
    }
