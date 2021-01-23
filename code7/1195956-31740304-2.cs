    static IEnumerable<string> SplitStringMyWay(string text, char delimitter)
    {
        string[] internalItems = text.Split(delimitter);
        List<string> theItems = new List<string>();
         string newItem = string.Empty;
        int openParenthesis = 0;
         foreach (string item in internalItems)
        {
            if (openParenthesis != 0) newItem += ",";
             newItem += item;
            openParenthesis += GetCharCount('(', item);
            openParenthesis -= GetCharCount(')', item);
             if (openParenthesis == 0)
            {
                theItems.Add(newItem);
              newItem = string.Empty;
            }
        }
         return theItems;
    }
    static int GetCharCount(char value, string text)
    {
        int count = 0;
        foreach (char character in text)
        {
            if (character == value)
            {
                count++;
            }
        }
         return count;
    }
