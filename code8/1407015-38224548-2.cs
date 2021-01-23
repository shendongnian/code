    lineNumber = 0;
    foreach (var line in File.ReadLines("worker2.csv"))
    {
        // split the line and create a FileLine instance.
        // we'll call it line2
        // Then, look to see if that line is in the File1Lines dictionary.
        FileLine line1;
        if (!File1Lines.TryGetValue(line2.Name, out line1))
        {
            // the line didn't exist in the first file
        }
        else
        {
            // Now compare individual fields
            if (line2.Age != line1.Age)
            {
                // report that fields are different
            }
            // Do the same with other fields
        }
    }
