    string key = "";
    for (int i = 1; i <= length; i++)
    {
        var c = (char)i;
        if (Char.IsPunctuation(c) || Char.IsLetterOrDigit(c))
            key += c;
    }
