    private static IEnumerable<string> Parse(string input)
    {
      // if used frequently, should be instantiated with Compiled option
      Regex regex = new Regex(@"(?<=^|,\s)(\""(?:[^\""]|\""\"")*\""|[^,\s]*)");
            
      return regex.Matches(inputData).Where(m => m.Success);
    }
