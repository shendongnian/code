        private const string DashComment = @"(^|\s+)--.*(\n|$)";
        private const string SlashStarComment = @"\/\*.*?\*\/";
        private string[] CommandSplitter(string text)
        {
            // strip /* ... */ comments
            var strip1 = Regex.Replace(text, SlashStarComment, " ", RegexOptions.Multiline);
            var strip2 = Regex.Replace(strip1, DashComment, "\n", RegexOptions.Multiline);
            // split into individual commands separated by '/'
            var lines = strip2.Split(new[] {'/'}, StringSplitOptions.RemoveEmptyEntries);
            return lines.Where(line => !String.IsNullOrWhiteSpace(line))
                .ToArray();
        }
