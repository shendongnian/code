    foreach (string currentField in currentRow)
    {
        // get the match text
        string matchText = match.Groups[0].ToString();
        // Define bad date
        Regex badDate = new Regex(@"(\s\d{2}\s[a-zA-Z]{3}\s\d{4})");
        // Find Matches
        MatchCollection matches = badDate.Matches(currentField);
        // Go through each match
        foreach (Match match in matches)
        {
            // Define DateTime
            DateTime parsedDate;
            // If it parses
            if (DateTime.TryParseExact(matchText, "dd MMM yyyy", new CultureInfo("en-US"),
                    DateTimeStyles.None, out parsedDate))
            {
                // Replace that specific text
                currentField = currentField.Replace(matchText,
                    parsedDate.ToString("MM/dd/yyyy 00:00"));
            }
        }
    }
