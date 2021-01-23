    public static IEnumerable<int> FindIndexesOfImpl(this IEnumerable<string> itemList, string indexesToFind)
    {
        var index = 0;
        foreach (var item in itemList)
        {
            if (item == indexesToFind)
                yield return index;
            index++;
        }
    }
