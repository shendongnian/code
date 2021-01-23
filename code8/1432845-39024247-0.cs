    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    static IEnumerable<string[]> ReadTabFile(string fileName, char delimiter)
    {
      return File.ReadLines(fileName).Select(line => line.Split(delimiter));
    }
    static void Main()
    {
      string[][] lines1 = ReadTabFile("text1.txt", '|').ToArray();
      string[][] lines2 = ReadTabFile("text2.txt", '|').ToArray();
      var leftOuterJoin = from line1 in lines1
                          join line2 in lines2
                          on line1.FirstOrDefault() equals line2.FirstOrDefault()
                          select new
                          {
                            line1,
                            line2
                          };
      var rightOuterJoin = from line2 in lines2
                           join line1 in lines1
                           on line2.FirstOrDefault() equals line1.FirstOrDefault()
                           select new
                           {
                             line1,
                             line2
                           };
      var fullOuterJoin = leftOuterJoin.Union(rightOuterJoin);
      foreach (var test in fullOuterJoin)
      {
        Console.WriteLine("{0,-40} - {1,-40}", string.Join("|", test.line1), string.Join("|", test.line2));
      }
    }
