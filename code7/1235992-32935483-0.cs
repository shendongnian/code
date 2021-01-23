    // Split the string in its word parts
    string[] parts = name.Split(' ');
    // Check if we have at least two words
    if(parts.Length > 1)
    {
        // Get the first char of the second word
        char c = parts[1][0];
        // Change char to upper following the culture rules of the current culture
        c = char.ToUpper(c, CultureInfo.CurrentCulture);
        
        // Create a new string using the upper char and the remainder of the string
        parts[1] = c + parts[1].Substring(1);
        // Now rebuild the name with the second word first letter changed to upper case
        name = string.Join(" ", parts);
    }
