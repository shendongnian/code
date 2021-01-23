    private static IEnumerable<double> GetByCondition(List<double> expiry, List<double> value)
    {
      for(int i = 0; i < expiry.Count; i++)
        if(expiry[i] == 0.75)
          yield return value[i];
    }
