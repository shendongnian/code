    static string GetProceduralSuffix(int value)
    {
        StringBuilder sb = new StringBuilder();
        while (value > 0)
        {
            int digit = value % 26;
            sb.Append((char)('a'+ digit));
            value /= 26;
        }
        if (sb.Length == 0)
        {
            sb.Append('a');
        }
        sb.Reverse();
        return sb.ToString();
    }
