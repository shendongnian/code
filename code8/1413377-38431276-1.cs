    public static bool SelfDescribing(string num)
    {
    
        char[] digit = num.ToArray();
        int bound = digit.Count();
    
        int sucessCount = 0;
        for (int i = 0; digit.Length != 0 && i < bound; i++)
        {
            var count = num.Count(x => x == char.Parse(i.ToString()));
            if (count == char.GetNumericValue(digit[i]))
            {
                sucessCount++;
            }
        }
        return sucessCount == digit.Length;
    }
