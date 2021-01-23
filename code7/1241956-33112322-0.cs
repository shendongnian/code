    private bool Compare(string pattern, string compare)
    {
        var patternArray = pattern.Split();
        var compareArray = compare.Split();
        if (patternArray.Count != compareArray.Count)
            //strings don't match
            return false;
        for(int x = 0, x < patternArray.Count, x++)
        {
            if (patternArray[x] != '*')
            {
                if (patternArray[x] != compareArray[x])
                    return false;
            }   
            return true;
        }
    }
