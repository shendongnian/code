     public static IEnumerable<int> Test(int a, int n, int x)
     {
        int i = 0;
        while (i < n)
        {
            if (a == x)
            {
              a++;
              continue;
            }
            i++;
            yield return a++;
       }
     }
    
