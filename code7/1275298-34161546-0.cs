    public static Dictionary<T, int> CompareLists<T>(List<T> listA, List<T> listB)
    {
        // 0        Match
        // <= -1    listB only
        // >= 1     listA only
        var recTable = new Dictionary<T, int>();
        foreach (T value in listA)
        {
            if (recTable.ContainsKey(value))
                recTable[value]++;
            else
                recTable[value] = 1;
        }
        foreach (T value in listB)
        {
            if (recTable.ContainsKey(value))
                recTable[value]--;
            else
                recTable[value] = -1;
        }
        return recTable;
    }
