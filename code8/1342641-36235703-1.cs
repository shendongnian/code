    private static final Regex dateRegex = new Regex(@"\d{2}.\d{2}.\d{4}");
    public static IEnumerable<string> ExtractDates(string input)
    {
         return from m in dateRegex.Matches(input).Cast<Match>()
                select m.Value.ToString();
    }
