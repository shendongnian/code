            string input = "Finding all possible schedules that could run at Thu Jul 02 09:30:00 EST 2015 on monitor AAA-AAA_NameOf Place";
            string pattern = @"\b(.)\1\1-\1\1\1_.+\Z";
            Match m = Regex.Match(input, pattern);
            if (m.Success)
            {
                Console.WriteLine(m.Value);
            }
