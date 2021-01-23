    string str = "-*‡€⁋™Жקओを";
    var sb = new StringBuilder();
    foreach (char ch in str)
    {
        bool isLetter = char.IsLetterOrDigit(ch);
        if (isLetter)
        {
            sb.Append(ch);
        }
    }
    string str2 = sb.ToString();
