    string text = MyInputMethod();
    const string MatchPhonePattern =
           @"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}";
            Regex rx = new Regex(MatchPhonePattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            // Find matches.
            MatchCollection matches = rx.Matches(text);
            // Report the number of matches found.
            int noOfMatches = matches.Count;
            //Do something with the matches
            foreach (Match match in matches)
            {
                //Do something with the matches
               string tempPhoneNumber= match.Value.ToString(); ;
             }
