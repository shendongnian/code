     var max = int.MinValue;
     var min = int.MaxValue;
     var array = new [] { 4, 7, 9, 3, 8, 6, 4, 3, 3, 9 };
     // Get min and max values. With just one iteration.
     foreach (var element in array)
         {
         if (element < min)
             {
             min = element;
             }
         if (max < element)
             {
             max = element;
             }
         }
     
     var minCount = 0;
     var maxCount = 0;
     var list = array.ToList ();
     // Search for duplicates with second iteration.
     for (int i = 0; i < list.Count; ++i)
         {
         if (list[i] == min)
             {
             if (minCount++ != 0)
                 {
                 list.RemoveAt (i--);
                 }
             continue;
             }
         if (list[i] == max)
             {
             if (maxCount++ != 0)
                 {
                 list.RemoveAt (i--);
                 }
             }
         }
     array = list.ToArray ();
