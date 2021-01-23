    public static int GetStartIndex(string letters)
    {
        int index = 0;
    
        for (int i = letters.Length - 1; i > 0; i--)
        {
            index += (int)Math.Pow(26, i);
        }
    
        return index;
    }
