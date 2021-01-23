    // just enumeration, coefficients aren't stored
    public static IEnumerable<int> Serie(Func<int, int> coefByIndex) {
      if (null == coefByIndex)
        throw new ArgumentNullException("coefByIndex");
    
      for (int i = 0; ; ++i)
        yield return coefByIndex(i);
    }
    
    // Let's sum up all 2**29 values, 
    // i.e. compute f(1) summing up 2**29 items (it's a long process...)
    // sum = 1.44115187606094E+17
    Double sum = Serie(index => index)
      .Select(x => x * 1.0)
      .Take(1 << 29)
      .Sum();
