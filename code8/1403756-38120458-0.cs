    private void DoSomething()
    {
      var lines1 = File.ReadAllLines(@"file1.csv");
      var lines2 = File.ReadAllLines(@"file2.csv");
    
      var diff1From2 = FindDifferences(lines1, lines2);
      var diff2From1 = FindDifferences(lines2, lines1);
    
      var diffs = new List<string>(diff1From2);
      diffs.AddRange(diff2From1);
      File.WriteAllLines(@"file3.csv", diffs);
    }
    
    private static string[] FindDifferences(string[] linesFirst, string[] linesSecond)
    {
      return (from line1 in linesFirst
        let isLineEqual = linesSecond.Any(line2 => line1 == line2)
        where isLineEqual == false
        select line1).ToArray();
    }
