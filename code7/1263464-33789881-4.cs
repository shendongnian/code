     static class HashSetExtensions
     {
         public static int IndexOf<T>(this HashSet<T> set, T element)
         {
             int index = 0;
             foreach (var item in set)
             {
                 if (element.Equals(item))
                 {
                     return index;
                 }
                index++;
            }
            return -1;
        }
    }
