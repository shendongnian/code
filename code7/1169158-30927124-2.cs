    var searchText = "Hello, World";
    var compareInfo = new CultureInfo("en-US").CompareInfo;
            
    var sb = new StringBuilder();
    for (var iter = doc.Start(); iter.IsValid(); ++iter)
    {
        var ch = iter.GetChar();
        sb.Append(ch);
    }
    var docString = sb.ToString();
            
    for (int i = 0; i < docString.Length; i++)
    {
        var matchIndex = compareInfo.IndexOf(docString, searchText, i);
        if (matchIndex > 0)
        {
            //match found at matchIndex, do whatever with it
            Console.WriteLine($"match at {start}-{iter}");
        }
    }
