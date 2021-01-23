    var lines = new List<string> { "aaabb", "ccddddd", "efffggggg" };
    foreach (var line in lines)
    {
        if (string.IsNullOrEmpty(line)) // if the line is null or empty then skip it.
        {
            Console.WriteLine("Empty or Null string.");
            continue;
        }
        char prev = line[0]; // The previous character seen starts with the first character
        int maxSeen = 0; // The maximum number of consecutive chars seen
        int maxSeenIndex = -1; // The index of the maximum seen chars.
        int currentSeen = 1; // The current number of consecutive chars seen.
        int currentSeenIndex = 0; // The index of the current chars seen.
        for (int i = 1; i < line.Length; i++) // Start at 1 to skip the first character.
        {
            if (prev == line[i]) // If the current character is the same as the previous
            {
                currentSeen++; // increment the number of current chars seen.
            }
            else // If the current character is different
            {
                if (currentSeen > maxSeen) // Check if the current Seen is more than max
                {
                    maxSeen = currentSeen;
                    maxSeenIndex = currentSeenIndex;
                }
                currentSeen = 1; // reset the current seen to 1
                currentSeenIndex = i; // set the current seen index to the current index
            }
            prev = line[i]; // set the current char to the previous
        }
        if (currentSeen > maxSeen) // Have to do this check again 
        {
            maxSeen = currentSeen;
            maxSeenIndex = currentSeenIndex;
        }
        Console.WriteLine(line.Substring(maxSeenIndex, maxSeen) + ", " + maxSeenIndex);
    }
