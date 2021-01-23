     public static bool ContainsAll<T>(this IEnumerable<T> list, params T[] items)
     {
         foreach(var item in items)
         {
             if (!list.Contains(item))
                 return false;
         }
         return true;
     }
