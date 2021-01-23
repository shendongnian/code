    private static Dictionary<int, string> knownLinks = new Dictionary<int, string>()
    {
      {123456, "www.test.com"},
      {999999, "www.foo.com"},
    };
    
    private static string LinkReplacer(Match match)
    {
      int linkNumber = Convert.ToInt32(match.Groups[1].Value);
      string link = knownLinks[linkNumber];
      return link;
    }
    public static void Replace()
    {
      string text = "testA M123456 testB Result M999999 testC";
      string replacedText = Regex.Replace(text, "M([0-9]{6})", LinkReplacer);
      Console.WriteLine(replacedText);
    }
    // output: testA www.test.com testB Result www.foo.com testC
