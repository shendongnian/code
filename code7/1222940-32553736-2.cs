    private Dictionary<string, int> PeriodicTable =
        new Dictionary<string, int>()
        {
            {"Li", 5 },
            {"Be", 9 }
            //more elements..
        };
    private int GetMass(string element)
    {
        //Is that element in the table?
        if (PeriodicTable.ContainsKey(element)) 
        {
            //Try to get it and return it 
            int value;
            PeriodicTable.TryGetValue(element, out value);
            return value;
        }
        else //not found
        {
            return -1;
        }
    }
