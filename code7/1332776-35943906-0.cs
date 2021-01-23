    for (int i = 0; i < chars.Length; i++) 
    {
        if (i % 2 != 0)
        {
            chars[i] = chars[i].ToUpper();
        }
        else
        {
            chars[i] = chars[i].ToLower();
        }
    }
