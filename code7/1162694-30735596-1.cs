    private static string trimString(string str, int maxCharacters = 16) {
        if (str.Length <= maxCharacters) {
            return str;
        }
        var suffixLength = maxCharacters / 2;
        // When maxCharacters is odd, prefix will be longer by one character
        var prefixLength = maxCharacters - suffixLength;
        return string.Format(
            "{0}...{1}"
        ,   str.Substring(0, prefixLength)
        ,   str.Substring(str.Length-suffixLength, suffixLength)
        );
    }
