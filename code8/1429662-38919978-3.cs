    // Loop, but skip the first line....
    foreach(string currentLine in target.Skip(1))
    {
        // split your line into an array of strings
        var lineElements = currentLine.Split(',');
 
        // Replace spaces with commas on the fifth column of lineElements 
        var replace = lineElements[4].Replace(' ', ',');
        // Add the changed line to the result list 
        results.Add(replace);
    }
    // move  outside the foreach loop the write of your changes 
    File.WriteAllLines(fileName, results.ToArray());
