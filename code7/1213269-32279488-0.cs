    public static class StringHelperClass
    {
        // Extension method to remove any unnecessary white-space and put a separator char instead.
        public static string[] ReplaceSpacesWithSeparator(this string[] text, string separator)
        {
            // Create an array of StringBuilder, one for every line in the text.
            StringBuilder[] stringBuilders = new StringBuilder[text.Length];
            // Initialize stringBuilders.
            for (int n = 0; n < text.Length; n++)
                stringBuilders[n] = new StringBuilder().Append(separator);
            // Get shortest line in the text, in order to avoid Out Of Range Exception.
            int shorterstLine = text.Min(line => line.Length);
            // Temporary variables.
            int lastSeparatorIndex = 0;
            bool previousCharWasSpace = false;
            // Start processing the text, char after char.
            for (int n = 0; n < shorterstLine; ++n)
            {
                // Look for white-spaces on the same position on
                // all the lines of the text.
                if (text.All(line => line[n] == ' '))
                {
                    // Go to next char if previous char was also a white-space,
                    // or if this is the first white-space char of the text.
                    if (previousCharWasSpace || n == 0)
                    {
                        previousCharWasSpace = true;
                        lastSeparatorIndex = n + 1;
                        continue;
                    }
                    previousCharWasSpace = true;
                    // Append non white-space chars to the StringBuilder
                    // of each line, for later use.
                    for (int i = lastSeparatorIndex; i < n; ++i)
                    {
                        for (int j = 0; j < text.Length; j++)
                            stringBuilders[j].Append(text[j][i]);
                    }
                    // Append separator char.
                    for (int j = 0; j < text.Length; j++)
                        stringBuilders[j].Append(separator);
                    lastSeparatorIndex = n + 1;
                }
                else
                    previousCharWasSpace = false;
            }
            for (int j = 0; j < text.Length; j++)
                text[j] = stringBuilders[j].ToString();
            // Return formatted text.
            return text;
        }
    }
