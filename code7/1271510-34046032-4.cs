    Encoding utf8 = Encoding.UTF8;
    Encoding latin9 = Encoding.GetEncoding("ISO-8859-15");
    Encoding iso = Encoding.GetEncoding(1252);
    var map = Dictionary<string, List<int>>();
    // same code to get each line from the file as per the linked answer
    while (true)
    {
        // break if líne is null
        //  parse codePoint
        // skip Unicode surrogate area
        if (IsSurrogateBoundary(codePoint))
            continue;
        string utf16String = char.ConvertFromUtf32(codePoint);
        byte[] utf8Bytes = utf8.GetBytes(utf16String);
        byte[] latin9Bytes = Encoding.Convert(utf8, latin9, utf8Bytes);
        string latin9String = latin9.GetString(latin9Bytes);
        byte[] isoBytes = Encoding.Convert(utf8, iso, utf8Bytes);
        string isoString = iso.GetString(isoBytes); // this is not always the same as latin9String!
       // fill the map using the isoString as key and 
       // the the list of mapped codePoints as Value
    }
