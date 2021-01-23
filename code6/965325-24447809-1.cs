    public static IEnumerable<int> FindIndexesOf(this IEnumerable<string> itemList, string indexesToFind)
    {
        if (itemList == null)
            throw new ArgumentNullException("itemList");
        if (indexesToFind == null)
            throw new ArgumentNullException("indexToFind");
        return FindIndexesOfImpl(itemList, indexesToFind);    
    }
    private static IEnumerable<int> FindIndexesOfImpl(this IEnumerable<string> itemList, string indexesToFind)
    {
        List<string> enumerable = itemList as List<string> ?? itemList.ToList();
        for (int i = 0; i < enumerable.Count(); i++)
        {
            if (enumerable[i] == indexesToFind)
                yield return i;
        }
    }
