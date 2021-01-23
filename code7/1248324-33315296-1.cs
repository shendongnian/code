    // You don't have to use StringBuilder, but it makes it easier to read.
    StringBuilder sb = new StringBuilder();
    // Iterate through and handle each character in string.
    int indentAmt = 0;
    string indentStr = string.Empty;
    foreach (char c in questions)
    {
        // Determine the indent of the current line.
        indentStr = string.Empty;
        for (int i = 0; i < indentAmt; i++)
            indentStr += "    ";
                
        // Update the indent amount.
        if (c == '{')
            indentAmt++;
        else if (c == '}')
            indentAmt--;
        // Add a new line, plus the character, if the character is one of the delimiters.
        if (delimiters.Contains(c))
            sb.Append(c.ToString() + Environment.NewLine + indentStr);
        else
            sb.Append(c);
    }
    questions = sb.ToString(); // BOOM.
