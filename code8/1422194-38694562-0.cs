    public static IEnumerable<String> GetTokens(this string value) {
      if (string.IsNullOrEmpty(value))
        yield break; // or throw exception in case of value == null
      bool inQuotation = false;
      int index = 0;
      for (int i = 0; i < value.Length; ++i) {
        char ch = value[i];
        if (ch == '"')
          inQuotation = !inQuotation;
        else if ((ch == ' ') && (!inQuotation)) {
          yield return value.Substring(index, i - index);
          index = i + 1;
        }
      }
      if (index < value.Length)
        yield return value.Substring(index, value.Length - index);
    }
