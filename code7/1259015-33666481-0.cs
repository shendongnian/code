    public static Dictionary<String, int> WordsToCounts(String value) {
      if (String.IsNullOrEmpty(value))
        return new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
    
      return value
        .Split(' ', '\r', '\n', '\t')
        .Select(item => item.Trim(',', '.', '?', '!', ':', ';', '"'))
        .Where(item => !String.IsNullOrEmpty(item))
        .GroupBy(item => item, StringComparer.OrdinalIgnoreCase)
        .ToDictionary(chunk => chunk.Key, 
                      chunk => chunk.Count(), 
                      StringComparer.OrdinalIgnoreCase);
    }
    
    public static Double DictionaryPercentage(
      IDictionary<String, int> left,
      IDictionary<String, int> right) {
    
      if (null == left)
        if (null == right)
          return 1.0;
        else
          return 0.0;
      else if (null == right)
        return 0.0;
    
      int all = left.Sum(pair => pair.Value);
    
      if (all <= 0)
        return 0.0;
    
      double found = 0.0;
    
      foreach (var pair in left) {
        int count;
    
        if (!right.TryGetValue(pair.Key, out count))
          count = 0;
    
        found += count < pair.Value ? count : pair.Value;
      }
    
      return found / all;
    }
    
    public static Double StringPercentage(String left, String right) {
      return DictionaryPercentage(WordsToCounts(left), WordsToCounts(right));
    }
