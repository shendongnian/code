    public static class Lists {
       private static System.Random rng = new System.Random();
       public static List<T> Shuffle<T>(this IEnumerable<T> tEnumeration) {
           var list = tEnumeration.ToList();
           int n = list .Count;
           while(n > 1) {
               n--;
               int k = rng.Next(n + 1);
               T value = list[k];
               list[k] = list[n];
               list[n] = value;
           }
           return list;
       }
    }
