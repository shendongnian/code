    var searchText = "Hello, World";
    var compareInfo = new CultureInfo("en-US").CompareInfo;
    DocumentIterator start = null; // the start position if a match occurs
    var sb = new StringBuilder();
    var startIndex = 0;
    var checkLength = 0;
    // the document is not a string, but exposes an iterator to its content
    for (var iter = doc.Start(); iter.IsValid(); ++iter)
    {
       start = start ?? iter; // the start of the potential match
       
       if((startIndex + checkLength) >= sb.Length)
       {
           var ch = iter.GetChar(); 
           sb.Append(ch);
       }
       else
           checkLength++;
       if (compareInfo.Compare(searchText, 
              sb.ToString(startIndex, checkLength)) == 0) // exact match
       {
           Console.WriteLine($"match at {start}-{iter}");
           // not shown: continue to search for more occurrences.
       }
       else if (!compareInfo.IsPrefix(criteria.Text, 
                 sb.ToString(startIndex, checkLength)))
       {
           // restart the search from the character immediately following start
           //sb.Clear();
           startIndex++;
           checkLength = 0;
           iter = start; // this gets incremented immediately
           start = null;
       }
    }
