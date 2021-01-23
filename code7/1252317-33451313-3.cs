    public char GetCommonChar(string text) {
      Dictionary<char, int> cnt = new Dictionary<char, int>();
      foreach (char c in text) {
        if (cnt.ContainsKey(c)) {
          cnt[c]++;
        } else {
          cnt.Add(c, 1);
        }
      }
      char result = ' ';
      int max = 0;
      foreach (KeyValuePair<char, int> item in cnt) {
        if (item.Value > max) {
          result = item.Key;
          max = item.Value;
        }
      }
      return result;
    }
