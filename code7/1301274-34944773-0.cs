    private static String CreateGroups(string source, int groupSize)
    {
        if (groupSize <= 0)
            throw new ArgumentOutOfRangeException("groupSize", "must be greater zero.");
        var sb = new StringBuilder();
        var firstGroupLength = source.Length % groupSize;
        var groupLength = firstGroupLength == 0 ? groupSize : firstGroupLength;
        foreach (var item in source)
        {
            sb.Append(item);
            groupLength--;
            if (groupLength == 0)
            {
                groupLength = groupSize;
                sb.Append(' ');
            }
        }
        return sb.ToString();
    }
