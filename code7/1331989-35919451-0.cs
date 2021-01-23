    public static string[] PotentialProductCodes(string input)
    {
      Regex codesSplit = new Regex("[0-9]{4,}", RegexOptions.Compiled);
      List<string> list = new List<string>();
      string curr = null;
      foreach (Match match in codesSplit .Matches(input))
      {        
        curr = match.Value;
        if (0 == curr.Length)
        {
          list.Add("");
        }
    list.Add(curr.TrimStart(','));
