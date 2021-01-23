    private static IEnumerable<String> SplitWithEscape(String source) {
      if (String.IsNullOrEmpty(source))
        yield break;
      int escapeCount = 0;
      int start = 0;
      for (int i = 0; i < source.Length; ++i) {
        char ch = source[i];
        if (escapeCount > 0) {
          if (ch == '(')
            escapeCount += 1;
          else if (ch == ')')
            escapeCount -= 1;
        }
        else {
          if (ch == ' ') {
            yield return source.Substring(start, i - start);
            start = i;
          }
          else if (ch == '(')
            escapeCount += 1;
        }
      }
      if ((start < source.Length - 1) && (escapeCount == 0))
        yield return source.Substring(start);
    }
    ....
    String source = "this is (a (string))";
    String[] split = SplitWithEscape(source).ToArray();
    Console.Write(String.Join("; ", split));
