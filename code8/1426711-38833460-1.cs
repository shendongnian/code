    // How many characters should be substituted in order to
    // turn the string into palindrom
    private static int PalindromeSubstitutions(string value) {
      if (string.IsNullOrEmpty(value))
        return 0;
      int result = 0;
      for (int i = 0; i < value.Length / 2; ++i)
        if (value[i] != value[value.Length - 1 - i])
          result += 1;
      return result;
    }
    // Let's test all substrings of size Length, Length - 1, ... , 2, 1
    // until we find substring with required tolerance
    private static string BestPalindromeSubstitutions(string value, int tolerance) {
      for (int size = value.Length; size >= 1; --size)
        for (int start = 0; start <= value.Length - size; ++start)
          if (PalindromeSubstitutions(value.Substring(start, size)) <= tolerance)
            return value.Substring(start, size);
      return "";
    }
    private static string SubstituteToPalindrome(string value) {
      if (string.IsNullOrEmpty(value))
        return value;
      StringBuilder sb = new StringBuilder(value);
      for (int i = 0; i < value.Length / 2; ++i) 
        sb[value.Length - 1 - i] = sb[i];
      
      return sb.ToString();
    }
