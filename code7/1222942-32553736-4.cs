    private Dictionary<string, int> PeriodicTable =
        new Dictionary<string, int>()
        {
            {"Li", 5 },
            {"Be", 9 }
            //more elements..
        };
    private int GetMass(string element)
    {
        int value = 0;
        //Try to get the value
        if (PeriodicTable.TryGetValue(element, out value))
            return value;
        else //not found
            return -1;
    }
