    public static IList<int> AllIndexOf(this string text, string str, StringComparison comparisonType)
    {
        IList<int> allIndeces = new List<int>();
        int index = text.IndexOf(str, comparisonType);
        while (index != -1)
        {
            allIndeces.Add(index);
            index = text.IndexOf(str, index + str.Length, comparisonType);
        }
        return allIndeces;
    }
