    private static string FirstLetters(string text)
    {
        string result = string.Empty;
        for (int i = 0; i < text.Length - 1; i++)
        {
            if (text[i] == ' ')
                result += Char.ToUpper(text[i + 1]);
        }
        return result;
    }
