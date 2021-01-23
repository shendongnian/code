     public static IEnumerable<int> GenerateNumbers(int a, int n, int x)
     {
        for (var i = 0; i < n; i++)
        {
            if (a == x)
            {
               i--;
               a++;
               continue;
            }
            yield return a++;
        }
     }
