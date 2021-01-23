    public static IEnumerable<double> GetValuesByExpiry(
      this List<double> self, List<double> values)
    {
      return GetByCondition(self, values);
    }
