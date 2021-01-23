    public static int EasyHash(string s)
    {
        ulong strHash = 0;
        const int multiplier = 37;
    
        for (int i = 0; i < s.Length; i++)
        {
            unchecked
            {
                strHash = (strHash * multiplier) + s[i];
            }
        }
    
        return (int)(strHash % 100);
    }
