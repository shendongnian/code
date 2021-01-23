    private static readonly char[] separator = { '.', ',', ';', ':', '-', '(', ')', '\\', '{', '}', '[', ']', '/', '\\', '\'', '"', '"', '?', '!', '|' };
    public static bool IsOrdinalNumber(string word)
    {
        if (word.Any(char.IsWhiteSpace))
            return false; // white-spaces are not allowed
        if (word.Length < 3)
            return false;
        var numericPart = word.TakeWhile(char.IsDigit);
        string numberText = string.Join("", numericPart);
        if (numberText.Length == 0)
            return false;
        int number;
        if (!int.TryParse(numberText, out number))
            return false; // handle unicode digits which are not really numeric like ۵
        string ordinalNumber;
        switch (number % 100)
        {
            case 11:
            case 12:
            case 13:
                ordinalNumber = number + "th";
                break;
        }
        switch (number % 10)
        {
            case 1:
                ordinalNumber = number + "st"; break;
            case 2:
                ordinalNumber = number + "nd"; break;
            case 3:
                ordinalNumber = number + "rd"; break;
            default:
                ordinalNumber = number + "th"; break;
        }
        string checkForOrdinalNum = numberText + word.Substring(numberText.Length);
        return checkForOrdinalNum.Equals(ordinalNumber, StringComparison.CurrentCultureIgnoreCase);
    }
    public static string ToTitleCaseIgnoreOrdinalNumbers(string text, TextInfo info)
    {
        if(text.Trim().Length < 3)
            return info.ToTitleCase(text);
        int whiteSpaceIndex = FindWhiteSpaceIndex(text, 0, separator);
        if(whiteSpaceIndex == -1)
        {
            if(IsOrdinalNumber(text.Trim()))
                return text;
            else
                return info.ToTitleCase(text);
        }
        StringBuilder sb = new StringBuilder();
        int wordStartIndex = 0; 
        if(whiteSpaceIndex == 0)
        {
            // starts with space, find word
            wordStartIndex = FindNonWhiteSpaceIndex(text, 1, separator);
            sb.Append(text.Remove(wordStartIndex)); // append leading spaces
        }
        while(wordStartIndex >= 0)
        {
            whiteSpaceIndex = FindWhiteSpaceIndex(text, wordStartIndex + 1, separator);
            string word;
            if(whiteSpaceIndex == -1)
                word = text.Substring(wordStartIndex);
            else
                word = text.Substring(wordStartIndex, whiteSpaceIndex - wordStartIndex);
            if(IsOrdinalNumber(word))
                sb.Append(word);
            else
                sb.Append(info.ToTitleCase(word));
            wordStartIndex = FindNonWhiteSpaceIndex(text, whiteSpaceIndex + 1, separator);
            string whiteSpaces;
            if(wordStartIndex >= 0)
                whiteSpaces = text.Substring(whiteSpaceIndex, wordStartIndex - whiteSpaceIndex);
            else
                whiteSpaces = text.Substring(whiteSpaceIndex);
            sb.Append(whiteSpaces); // append spaces between words
        }
        
        return sb.ToString();
    }
    public static int FindWhiteSpaceIndex(string text, int startIndex = 0, params char[] separator)
    {
        bool checkSeparator = separator != null && separator.Any();
        for (int i = startIndex; i < text.Length; i++)
        {
            char c = text[i];
            if (char.IsWhiteSpace(c) || (checkSeparator && separator.Contains(c)))
                return i;
        }
        return -1;
    }
    public static int FindNonWhiteSpaceIndex(string text, int startIndex = 0, params char[] separator)
    {
        bool checkSeparator = separator != null && separator.Any();
        for (int i = startIndex; i < text.Length; i++)
        {
            char c = text[i];
            if (!char.IsWhiteSpace(text[i]) && (!checkSeparator || !separator.Contains(c)))
                return i;
        }
        return -1;
    }
