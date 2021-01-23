    var searchText = "Hello, World";
    var compareInfo = new CultureInfo("en-US").CompareInfo;
    DocumentIterator start = null; // the start position if a match occurs
    var sb = new StringBuilder();
    int chunksize = 1000; //whatever makes sense
    int matchIndex = 0;
    // the document is not a string, but exposes an iterator to its content
    for (var iter = doc.Start(); iter.IsValid(); ++iter)
    {
        start = start ?? iter; // the start of the potential match
        if (matchIndex > 0) //after a match, iterate to the new starting position
        {
            matchIndex--;
            continue;
        }
        var ch = iter.GetChar();
        sb.Append(ch);
        
        if (sb.Length != chunksize)
            continue;
        var haystack = sb.ToString();
        for (int i = 0; i < haystack.Length; i++)
        {
            matchIndex = compareInfo.IndexOf(haystack, haystack, i);
            if (matchIndex > 0)
            {
                //match found at matchIndex, do whatever with it
                Console.WriteLine($"match at {start}-{iter}");
                sb.Clear();
                iter = start;
                start = null;
            }
            //add extra logic for detecting .IsPrefix...
        }
        if (matchIndex == 0) //no match
            matchIndex == searchText.Length; //we know that we can skip at least this many
    }
