    public int[] Types
    {
        get
        {
             return Enumerable.Range(0, NumberOfItems).Select(getTypeForItem).ToArray();
        }
    }
