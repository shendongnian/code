    public static IEnumerable<int> AllIndexesOf(this string str, string searchText)
    {
        if (str == null)
            throw new ArgumentNullException("str");
        if (searchText == null)
            throw new ArgumentNullException("searchText");
        return AllIndexesOfCore(str, searchText);
    }
    private static IEnumerable<int> AllIndexesOfCore(string str, string searchText)
    {
        for (int index = 0; ; index += searchText.Length)
        {
            index = str.IndexOf(searchText, index);
            if (index == -1)
                break;
            yield return index;
        }
    }
