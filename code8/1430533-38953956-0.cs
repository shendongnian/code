    // If we put "FindPrimes", let's return them: List<int> instead of void
    public static List<int> FindPrimes(int max) {
      if (max < 2)
        return new List<int>();
      // Try avoid explict adding .Add(), but generating
      List<int> result = Enumerable
        .Range(2, max - 1)
        .ToList();
      // seiving out the initial list
      for (int i = 1; i < result.Count; ++i) {
        int prime = result[i - 1];
        // removing all numbers that can be divided by prime found
        // when removing we should loop backward
        for (int j = result.Count - 1; j > i; --j)
          if (result[j] % prime == 0)
            result.RemoveAt(j); 
      }
      return result;
    }
