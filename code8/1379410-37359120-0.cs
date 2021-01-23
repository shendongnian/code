    class Item
    {
        public int sum;
        public int prod;
        public int index;
    }
    int[] sums = new int[] { 12, 12, 12, 13, 13, 18 };
    int[] prods = new int[] { 67, 52, 60, 42, 17, 21 };
     int[] indexes = new int[] { 38, 107, 11, 98, 4, 60 };
    List<Item> Items = new List<Item>();
    for (int i = 0; i < sums.Length; i++)
    {
        Item Item = new Item();
        Item.sum = sums[i];
        Item.prod = prods[i];
        Item.index = indexes[i];
        Items.Add(Item);
    }
    Items = Items.OrderBy(I => I.sum).ThenBy(I => I.prod).ThenBy(I => I.index).ToList();
    sums = Items.Select(I => I.sum).ToArray();
    prods = Items.Select(I => I.prod).ToArray();
    indexes= Items.Select(I => I.index).ToArray();
