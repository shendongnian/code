    public char GetCommonChar(string text) {
      char result = ' ';
      int max = 0;
      foreach (char c in text) {
        int cnt = text.Count(i => i == c);
        if (cnt > max) {
          result = c;
          max = cnt;
        }
      }
      return result;
    }
