        static string MatchQuotedString(string input)
            {
            const string pattern = @"""(?<Result>(\\""|.)*)""";
            const RegexOptions options = RegexOptions.ExplicitCapture;
            Regex regex = new Regex(pattern, options);
            var matches = regex.Match(input);
            var substring = matches.Groups["Result"].Value;
            return substring;
            }
