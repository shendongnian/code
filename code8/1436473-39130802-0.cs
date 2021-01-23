    private Dictionary<string, bool> ChangeValues(int line, Dictionary<string, bool> values, string[] keys)
    {
        for (int i = 0; i < line; i++)
        {
            for (int j = 0, bit = 1; j < keys.Length; j++, bit <<= 1)
            {
                values[keys[j]] = (i & bit) != 0;
            }
        }
        return values;
    }
