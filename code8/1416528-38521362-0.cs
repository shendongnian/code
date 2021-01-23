    public static string Highlight(string text, string highlight, string prepend, string append)
    {
        StringBuilder result = new StringBuilder();
        int position = 0;
        int previousPosition = 0;
        while (position >= 0)
        {
            position = text.IndexOf(highlight, position, 
                StringComparison.InvariantCultureIgnoreCase);
            if (position >= 0)
            {
                result.Append(text.Substring(previousPosition, position - previousPosition));
                result.Append(prepend);
                result.Append(text.Substring(position, highlight.Length));
                result.Append(prepend);
                previousPosition = position + highlight.Length;
                position++;
            }
            else
            {
                result.Append(text.Substring(previousPosition));
            }
        }
        return result.ToString();
    }
