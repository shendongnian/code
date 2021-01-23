    public String RemoveLastElem(String myStr)
    {
        String result = "";
        if (myStr.Length > 2)
        {
            // Ignore very last new-line character.
            String temporary = myStr.Substring(0, myStr.Length - 2);
            
            // Get the position of the last new-line character.
            int lastNewLine = temporary.LastIndexOf("\r\n");
            
            // If we have at least two elements separated by a new-line character.
            if (lastNewLine != -1)
            {
                // Cut the string (starting from 0, ending at the last new-line character).
                result = myStr.Substring(0, lastNewLine);
            }
        }
        return (result);
    }
