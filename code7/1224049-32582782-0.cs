    string s = "3 ( 16 ) 23 ( 24 ( 40 ) 50 ( 66 ) 76 ) 83 ( 88 ( 104 ) 127 )".Replace(" ", string.Empty);
    Regex regex = new Regex(@"(([0-9]+)\([0-9]+\))");
    Regex regexNumber = new Regex(@"[0-9]+");
    Match match = regex.Match(s);
    List<Tuple<int, int>> pairs = new List<Tuple<int, int>>();
    while (match.Success)
    {
         var pairNumber = regexNumber.Matches(match.Value);
         if (pairNumber.Count == 2)
         {
             var newPair = new Tuple<int, int>(int.Parse(pairNumber[0].Value), int.Parse(pairNumber[1].Value));
             pairs.Add(newPair);
         }
         // remove last parse
         s = s.Replace(match.Value, string.Empty);
         match = regex.Match(s);
     }
