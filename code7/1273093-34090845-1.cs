    bool Contains(string description, string keyword)
    {
        int index = 0;
        while (true)
        {
            index = description.IndexOf(keyword, index);
            if (index == -1) // Not in string.
            {
                return false;
            }
            if (index == 0) // Start of string.
            {
                return true;
            }
            if (char.IsWhiteSpace(description[index - 1])) // Is previous index whitespace?
            {
                return true;
            }
            index = index + 1;
        }
    }
