    string foo = "Hello!";
    foreach (char c in foo)
    {  
        UnicodeCategory cat = CharUnicodeInfo.GetUnicodeCategory(c);
        if (cat == UnicodeCategory.LowercaseLetter || cat == UnicodeCategory.UppercaseLetter)
        {
            // Do what I want with letters
        }
        else if (cat == UnicodeCategory.DecimalDigitNumber)
        {
            // Do what I want with numbers
        }
        else if (c == '-' || c == '.')
        {
            // Do what I want with symbols
        }
    }
