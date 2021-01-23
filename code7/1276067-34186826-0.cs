    public static string Process (string s)
        {
            var split = s.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            if (split.Length < 2)
                return null; // impossible to find something if the length is not at least two
            string currentString = null;
            string nextString = null;
            for (var i = 0; i < split.Length - 1; i++)
            {
                var str = split[i];
                if (str.Length == 0) continue;
                var lastChar = str[str.Length - 1];
                var nextStr = split[i + 1];
                if (nextStr.Length == 0) continue;
                var nextChar = nextStr[0];
                if (lastChar == nextChar)
                {
                    if (currentString == null)
                    {
                        currentString = str;
                        nextString = nextStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                    }
                    else
                    {
                        if (str.Length > currentString.Length)
                        {
                            currentString = str;
                            nextString = nextStr.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
                        }
                    }
                }
            }
            return currentString == null ? null : currentString + "\n" + nextString;
        }
