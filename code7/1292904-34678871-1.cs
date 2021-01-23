    public static IList<int> AllIndexOf(this string text, string str, StringComparison comparisonType = StringComparison.CurrentCulture)
    {
        IList<int> allIndexes = new List<int>();
        int index = text.IndexOf(str, comparisonType);
        while (index != -1)
        {
            allIndexes.Add(index);
            index = text.IndexOf(str, index + str.Length, comparisonType);
        }
        return allIndexes;
    }
