    string file = File.ReadAllText("C:\\\\Users\\hacknj\\Desktop\\mo_daily_activity_20160627_1412.txt");
    // Define bad date
    Regex badDate = new Regex(@"(\s\d{2}\s[a-zA-Z]{3}\s\d{4})");
    // Find Matches
    MatchCollection matches = badDate.Matches(file);
    // Go through each match
    foreach (Match match in matches)
    {
        // get the match text
        string matchText = match.Groups[0].ToString();
        // Define DateTime
        DateTime parsedDate;
        // If it parses
        if (DateTime.TryParseExact(matchText, "dd MMM yyyy", new CultureInfo("en-US"),
                DateTimeStyles.None, out parsedDate))
        {
            // Replace that specific text
            file = file.Replace(matchText,
                parsedDate.ToString("MM/dd/yyyy 00:00"));
        }
    }
    File.WriteAllText("C:\\\\Users\\hacknj\\Desktop\\mo_daily_activity_20160627_1412.txt", file);
