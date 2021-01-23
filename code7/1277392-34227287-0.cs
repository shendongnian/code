     // Match a Regex and Do Stuff
            public void showMatch(string input, string expr)
            {
                MatchCollection mc = Regex.Matches(input, expr); 
                int num = 0;  
                foreach (Match m in mc)
                {
                    string tm = m.ToString();
                    num++;
                    if (num == 1)
                    {
                        // Do Stuff if 1 match.
                    }
                    if (num == 2)
                    {
                        // Do Stuff if 2 matches.
                    }
                }
           }
    
                // showMatch(input, @"(?:[0-9]+){17}");
