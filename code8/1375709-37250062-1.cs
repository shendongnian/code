      string input = "Test$String?";
      string pattern = "([\\^$()%.\\[\\]*+\\-?])";
      string replacement = "%$1";
      Regex rgx = new Regex(pattern);
      string result = rgx.Replace(input, replacement);
      Console.WriteLine("Original String: {0}", input);
      Console.WriteLine("Replacement String: {0}", result);   
