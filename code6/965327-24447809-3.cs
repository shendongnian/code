    public static IEnumerable<int> FindIndexesOfImpl(this IEnumerable<string> itemList, string indexesToFind)
    {
        return itemList
            .Select((item, index) => new { item, index })
            .Where(element => element.item == indexesToFind)
            .Select(element => element.index);
    }
