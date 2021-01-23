    public static class Extensions
    {
       private static Random rnd = new Random();
       public static void Shuffle<T>(this IList<T> collection)
       {
           int n = collection.Count;
           while (n > 1)
           {
               n--;
               int k = rnd.Next(n + 1);
               T value = collection[k];
               collection[k] = collection[n];
               collection[n] = value;
           }
       }
    }
