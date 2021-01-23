    static class Extention
    {
        // "this string text" allows this function to work as an extention
        public static string[] SplitOutsideSingleQuotes(this string text, char splittingChar)
        {
            bool insideSingleQuotes = false;
            List<string> parts = new List<string>() { "" };
            foreach (char ch in text)
            {
                if (ch == '\'')
                {
                    insideSingleQuotes = !insideSingleQuotes;
                    continue;
                }
                if (ch == ',' && !insideSingleQuotes)
                {
                    parts.Add("");
                }
                else
                    parts[parts.Count - 1] += ch;
            }
            return parts.ToArray();
        }
    }
