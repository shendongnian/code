    StringBuilder sb = new StringBuilder();
    bool previousWasSpace = true;
    char? firstLetterOfWord = null;
    foreach (char c in str)
    {
        if ((c >= 'a' && c <= 'z') || c == '_')
        {
            if (firstLetterOfWord != null)
            {
                sb.Append(firstLetterOfWord).Append(c);
                firstLetterOfWord = null;
                previousWasSpace = false;
            }
            else if (previousWasSpace)
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
            if (!previousWasSpace)
            {
                sb.Append(' ');
                previousWasSpace = true;
            }
        }
    }
    Console.WriteLine(sb.ToString());
