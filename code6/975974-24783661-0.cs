    public static class ItemFactory
    {
        public static Dictionary<string, Item> _Items = new Dictionary<string, Item>;
    
        public static Item GetItem(string itemNumber)
        {
            if(!_Items.ContainsKey(itemNumber))
            {
                _Items[itemNumber] = new Item(itemNumber);
                // Initialize item if necessary
            }
    
            return _Items[itemNumber];
        }
    }
