    static class Extention
    {
        // "this string text" allows this function to work as an extention
        public static string[] SplitOutsideSingleQuotes(this string text, char splittingChar)
        {
            bool insideSingleQuotes = false;
            List<string> parts = new List<string>() { "" }; // The part in which the text is split
            foreach (char ch in text)
            {
                if (ch == '\'') // Determine whenever we enter or exit a single quote
                {
                    insideSingleQuotes = !insideSingleQuotes;
                    continue; // The single quote shall not be in the final output. Therefore continue
                }
                if (ch == splittingChar && !insideSingleQuotes)
                {
                    parts.Add(""); // There is a 'splittingChar'! Create new part
                }
                else
                    parts[parts.Count - 1] += ch; // Add the current char to the latest part
            }
            return parts.ToArray();
        }
    }
