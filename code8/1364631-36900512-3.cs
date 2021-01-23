    StringBuilder sb = new StringBuilder();
    char? firstLetterOfWord = default(char?);
    foreach (char c in str)
    {
        int length = sb.Length;
        if ((c >= 'a' && c <= 'z') || c == '_')
        {
            if (firstLetterOfWord != null)
            {
                sb.Append(firstLetterOfWord);
                sb.Append(c);
                firstLetterOfWord = null;
            }
            else if (length == 0 || sb[length - 1] == ' ')
            {
                firstLetterOfWord = c;
            }
            else
            {
                sb.Append(c);
            }
        }
        else
        {
            firstLetterOfWord = null;
            if (length > 0 && sb[length - 1] != ' ')
            {
                sb.Append(' ');
            }
        }
    }
    Console.WriteLine(sb.ToString());
