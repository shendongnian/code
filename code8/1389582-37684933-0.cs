    // Loop approach
    for(var i = 0; i < splits.Length; i++)
    {
        splits[i] = splits[i].TrimEnd('\"');
    }
    // LINQ projection
    splits = splits.Select(s => s.TrimEnd('\"')).ToArray();
 
