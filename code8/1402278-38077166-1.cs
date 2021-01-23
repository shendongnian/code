    public static bool Like(String value, String like) {
      if (String.IsNullOrEmpty(like) || String.IsNullOrEmpty(value))
        return false; // or throw exception
      String pattern = "^" + Regex.Escape(like).Replace("%", ".*").Replace("_", ".") + "$";
      return Regex.IsMatch(value, pattern);
    }
....
    String source = "abcdef";
    // true
    bool result = Like(source, "%b_d%");
