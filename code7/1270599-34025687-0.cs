        private bool Equivalent(string patternOne, string patternTwo)
        {
            // convert both patterns to regexes based on rules for Directory.GetFiles
            var expressionOne = FilePatternToRegex(patternOne);
            var expressionTwo = FilePatternToRegex(patternTwo);
            // if either regex matches the opposite pattern, we've got a conflict
            return expressionTwo.IsMatch(patternOne) || expressionOne.IsMatch(patternTwo);
        }
        Regex FilePatternToRegex(string pattern)
        {
            // separate extension and filename
            var extension = Path.GetExtension(pattern);
            var filename = Path.GetFileNameWithoutExtension(pattern);
            // escape filename
            filename = EscapeFilePattern(filename);
            // 3 character extensions are a special case -- should be greedy eg xls matches xlsx
            // extension.Length == 4 bc its dot AND 3 characters
            if (extension.Length == 4 && !extension.Contains("*") && !extension.Contains("?"))
            {
                extension = extension + ".*";
            }
            else
            {
                // all other extension lengths just get escaped like normal regexes
                extension = EscapeFilePattern(extension);
            }
            // our final pattern should also only match at the string start/end
            var finalPattern = "\\A" + filename + extension + "\\z";
            return new Regex(finalPattern);
        }
        string EscapeFilePattern(string pattern)
        {
            // escape star and question mark bc they are filepattern significant
            pattern = pattern.Replace("*", "%S%").Replace("?", "%Q%");
            // escape all other special regex characters
            pattern = Regex.Escape(pattern);
            // turn star and question mark into their regex equivalents
            pattern = pattern.Replace("%S%", ".+").Replace("%Q%", ".");
            return pattern;
        } = Regex.Escape(pattern);
            pattern = pattern.Replace("%S%", ".+").Replace("%Q%", ".");
            return pattern;
        }
