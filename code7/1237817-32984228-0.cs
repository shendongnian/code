    public static string FindNegative(int[] array)
    {
        string yes = null;
        foreach (var n in array)
          {
            if (n < 0)
            {
                yes += (Array.IndexOf(array, n) + ":" + n + ",");  
            }
            
        }
        return yes;
    }
