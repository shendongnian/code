     private string[] SplitString(string inputString)
     {
          System.Text.RegularExpressions.RegexOptions options = ((System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace | System.Text.RegularExpressions.RegexOptions.Multiline)
                            | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
         Regex reg = new Regex("(?:^|,)(\\\"(?:[^\\\"]+|\\\"\\\")*\\\"|[^,]*)", options);
         MatchCollection coll = reg.Matches(inputString);
         string[] items = new string[coll.Count];
         int i = 0;
         foreach (Match m in coll)
         {
            items[i++] = m.Groups[0].Value.Trim('"').Trim(',').Trim('"').Trim();
         }
          return items;
     }
