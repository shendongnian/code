     static class HashSetExtensions
     {
        public static int AddWithIndex<T>(this HashSet<T> set, T element)
        {
            if (set.Add(element))
            {
                return set.Count - 1;
            }
            return set.IndexOf(element);
        }
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
