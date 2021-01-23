    public static class MyStringExtensions
    {
      public static bool Like(this string toSearch, string toFind)
      {
       return new Regex(@"\A" + new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\" + ch).Replace('_', '.').Replace("%", ".*") +  @"\z", RegexOptions.Singleline).IsMatch(toSearch);
      }
    }
    examples:
    bool willBeTrue = "abcdefg".Like("abcd_fg");
    bool willAlsoBeTrue = "abcdefg".Like("ab%f%");
    bool willBeFalse = "abcdefghi".Like("abcd_fg");
