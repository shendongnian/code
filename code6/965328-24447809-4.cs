    public static IEnumerable<int> FindIndexesOf(this IEnumerable<string> itemList, string indexesToFind)
    {
        if (itemList == null)
            throw new ArgumentNullException("itemList");
        if (indexesToFind == null)
            throw new ArgumentNullException("indexToFind");
        return itemList
            .Select((item, index) => new { item, index })
            .Where(element => element.item == indexesToFind)
            .Select(element => element.index);
    }
