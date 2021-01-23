    public static class StringExtensions
    {
      public static string ToLimitedString(this string instance,
        string validCharacters)
      {
        // null reference checking...
        var result = new string(instance
          .Where(c => validCharacters.Contains(c))
          .ToArray());
        return result;
      }
    }
