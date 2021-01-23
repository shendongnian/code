    List<string> _hackedValues = new List<string>();
    static void PrecomputeValues()
    {
        // 531441 = 27 ^ 4, i.e. the first 5-digit base 27 number.
        // That's a large enough number to ensure that the output
        // include "aaaz", and indeed almost all of the 4-digit
        // base 27 numbers
        for (int i = 0; i < 531441; i++)
        {
            string text = ToBase27AlphaString(i);
            if (!text.Contains('`'))
            {
                _hackedValues.Add(text);
            }
        }
    }
    static string GetProceduralSuffix(int value)
    {
        if (hackedValues.Count == 0)
        {
            PrecomputeValues();
        }
        return _hackedValues[value];
    }
    static string ToBase27AlphaString(int value)
    {
        StringBuilder sb = new StringBuilder();
        while (value > 0)
        {
            int digit = value % 27;
            sb.Append((char)('`'+ digit));
            value /= 27;
        }
        if (sb.Length == 0)
        {
            sb.Append('`');
        }
        sb.Reverse();
        return sb.ToString();
    }
