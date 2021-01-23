    public static Dictionary<T, int> CompareLists<T>(IEnumerable<T> listA, 
        IEnumerable<T> listB, IEqualityComparer<T> comp)
    {
        var recTable = new Dictionary<T, int>(comp);
        foreach (var value in listA)
        {
            if (recTable.ContainsKey(value))
                recTable[value]++;
            else
                recTable[value] = 1;
        }
        foreach (var value in listB)
        {
            if (recTable.ContainsKey(value))
                recTable[value]--;
            else
                recTable[value] = -1;
        }
        return recTable;
    }
