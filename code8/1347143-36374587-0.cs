    string[] documentText = File.ReadAllLines()
    
    foreach(string line in documentText)
    {
        // Skip empty lines
        if(line == string.Empty)
            continue;
    
        // Check the first character
        switch(line[0])
        {
            case '~': // Correct answer, skip
                break;
            case '-': // Wrong answer, skip
                break;
            case '&': // Multiple choice
                // Handle multiple choice here
                break;
            case '?': // Textbox queston
                // Handle textbox questions here
                break;
        }
    }
