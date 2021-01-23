    Encoding utf8 = Encoding.UTF8;
    Encoding latin9 = Encoding.GetEncoding("ISO-8859-15");
    Encoding iso = Encoding.GetEncoding(1252);
    var map = new Dictionary<string, List<string>>();
    // same code to get each line from the file as per the linked answer
    while (true)
    {
        string line = reader.ReadLine();
        if (line == null) break;
        string codePointHexAsString = line.Substring(0, line.IndexOf(";"));
        int codePoint = Convert.ToInt32(codePointHexAsString, 16);
        // skip Unicode surrogate area
        if (codePoint >= 0xD800 && codePoint <= 0xDFFF)
            continue;
        string utf16String = char.ConvertFromUtf32(codePoint);
        byte[] utf8Bytes = utf8.GetBytes(utf16String);
        byte[] latin9Bytes = Encoding.Convert(utf8, latin9, utf8Bytes);
        string latin9String = latin9.GetString(latin9Bytes);
        byte[] isoBytes = Encoding.Convert(utf8, iso, utf8Bytes);
        string isoString = iso.GetString(isoBytes); // this is not always the same as latin9String!
       string latin9HexAsString = latin9[0].ToString("X");
        if (!map.ContainsKey(latin9HexAsString))
        {
            isoMap[latin9HexAsString] = new List<string>();
        }
        isoMap[latin9HexAsString].Add(codePointHexAsString);
    }
