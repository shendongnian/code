		using System.Text.RegularExpressions;
        private char extractChar(string test)
        {
            char charOut = '\0';
            var matches = Regex.Matches(test, "^[a-zA-Z]+[0-9]+([a-zA-Z])[0-9]+.+");
            if (matches.Count > 0)
                charOut = matches[0].Groups[1].Value[0];
            return charOut;
        }
