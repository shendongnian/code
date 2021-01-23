     private static IEnumerable<bool> ToBinary(this int n)
     {
         for (int i = 0; i < 32; i++)
         {
             yield return (n & (1 << i)) > 0;
         }
     }
     private static int ToInt(this IEnumerable<bool> b)
     {
         var n = 0;
         var counter = 0;
         foreach (var i in b)
         {
             n = n | (i ? 1 : 0) << counter;
             counter++;
         }
         return n;
     }
     private static IEnumerable<bool> Trim(this IEnumerable<bool> list)
     {
         bool trim = true;
         foreach (var i in list)
         {
             if (i)
             {
                 trim = false;
             }
             if (!trim)
             {
                 yield return i;
             }
         }
     }
