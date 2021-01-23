    foreach (string currentField in currentRow)
    {
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
            if (DateTime.TryParseExact(match.Groups[0].ToString(), "dd MMM yyyy", new CultureInfo("en-US"),
                    DateTimeStyles.None, out parsedDate))
            {
                // Replace that specific text
                currentField = currentField.Replace(match.Groups[0].ToString(),
                    parsedDate.ToString("MM/dd/yyyy 00:00"));
            }
        }
    }
