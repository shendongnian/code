    enum ItemType
    {
        RatTail,
        WolfTail,
        Stuff1,
        Stuff2
    }
    Dictionary<ItemType, int> Level1 = new Dictionary<ItemType, int>
    {
        {RatTail, 10}
    };
    Dictionary<ItemType, int> Level2 = new Dictionary<ItemType, int>
    {
        {RatTail, 18},
        {WolfTail, 2}
    };
    // Additional levels here
