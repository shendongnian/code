        // use these regex patterns
        
         public string RemoveSQLComments(string sqlQuery)
            {
                Regex r1 = new Regex(@"(\/\*)[^(\*\/)]*(\*\/)", System.Text.RegularExpressions.RegexOptions.Multiline &
                                      System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                Regex r2 = new Regex("(--)[^\r\n$]*(?=(\r|\n|$))", System.Text.RegularExpressions.RegexOptions.Multiline &
                                      System.Text.RegularExpressions.RegexOptions.IgnoreCase);
    
                return r2.Replace(r1.Replace(sqlQuery, ""), "");
            }
