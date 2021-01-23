    using System;
    using System.Text.RegularExpressions;
    namespace myapp
    {
      class Class1
        {
          static void Main(string[] args)
            {
              String sourcestring = @"(Project in (""CI"") and Status in (""Open"") and issueType in (""Action Item"")) or issueKey = ""GR L-1"" order by Created asc";
              Regex re = new Regex(@"\(""(?<word>[A-Za-z0-9\s]+)""\)");
              MatchCollection mc = re.Matches(sourcestring);
              int mIdx=0;
              foreach (Match m in mc)
               {
                for (int gIdx = 0; gIdx < m.Groups.Count; gIdx++)
                  {
                    Console.WriteLine("[{0}][{1}] = {2}", mIdx, re.GetGroupNames()[gIdx], m.Groups[gIdx].Value);
                  }
                mIdx++;
              }
            }
        }
    }
