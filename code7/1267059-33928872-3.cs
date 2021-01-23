    public static string RemoveRepetitions(string original, int count)
    {
        if (original.Length % count != 0)
        {
            return null;
        }
        var temp = new char[original.Length / count];
        for (int i = 0; i < original.Length; i += count)
        {
            temp[i / count] = original[i];
        }
    
        return new string(temp);
    }
