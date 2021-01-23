    public static IEnumerable<int> GetItemsList3(HashSet<DateTime> requiredTimestamps)
    {
        var tmp = _containedObjects;
        List<int> toReturn = new List<int>();
        foreach (DateTime dateTime in requiredTimestamps)
        {
            int found;
            if (tmp.TryGetValue(dateTime, out found))
            {
                toReturn.Add(found);
            }
        }
        return toReturn;
    }
