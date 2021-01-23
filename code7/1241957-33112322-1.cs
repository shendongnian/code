    private bool Compare(string pattern, string compare)
    {
        if (pattern.Length != compare.Length)
            //strings don't match
            return false;
        for(int x = 0, x < pattern.Length, x++)
        {
            if (pattern[x] != '*')
            {
                if (pattern[x] != compare[x])
                    return false;
            }
        }
        return true;
    }
