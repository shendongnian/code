    public static string RemoveDuplicates(string input)
    {
        string sResult = string.Empty;
        char cTemp = '\0';
        foreach (char cItem in input)
        {
            if (cItem != cTemp)
            {
                sResult += cItem;
            }
            cTemp = cItem;
        }
        return sResult;
    }
