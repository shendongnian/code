<!-- -->
    string pattern = "X&&&&&&-X&&&&&&&";
    string text = "Xabcdef-Xasdfghi";
    
    var culture = CultureInfo.GetCultureInfo("sv-SE");
    var matcher = new MaskedTextProvider(pattern, culture);
    int position;
    MaskedTextResultHint hint;
    if (!matcher.Set(text, out position, out hint))
    {
        Console.WriteLine("Error at {0}: {1}", position, hint);
    }
    else if (!matcher.MaskCompleted)
    {
        Console.WriteLine("Not enough characters");
    }
    else if (matcher.ToString() != text)
    {
        Console.WriteLine("Missing literals");
    }
    else
    {
        Console.WriteLine("OK");
    }
