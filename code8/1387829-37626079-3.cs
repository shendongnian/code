        static string FixHyperlinks(string source)
        {
            const string pattern = "HYPERLINK \"(.+)\"";
            // Get a list of all the matches in the source
            var matches = Regex.Matches(source, pattern);
            // Replace all the matches
            return matches.Cast<Match>().Aggregate(source, (current, match) => current.Replace(match.Value, ""));
        }
