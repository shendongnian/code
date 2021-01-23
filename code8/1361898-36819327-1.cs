    public static string ToSentence(this string value)
    {
        char[] letters = value.ToCharArray();
        var sb = new StringBuilder(letters[0].ToString());
        for (int charIndex = 2; charIndex <= letters.Length; charIndex++)
        {
            char previousChar = letters[charIndex - 1];
            char currentChar = charIndex < letters.Length ? letters[charIndex] : 'a';
            if (Char.IsUpper(previousChar) && Char.IsLower(currentChar))
            {
                sb.Append(" ");
            }
            sb.Append(previousChar);
            if (Char.IsLower(previousChar) && Char.IsUpper(currentChar))
            {
                sb.Append(" ");
            }
        }
        return sb.ToString();
    }
