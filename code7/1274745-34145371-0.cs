    public IEnumerable<Item> GetItems()
    {
       int i = 0;
       while(i < 100) // or foreach(Item item in _baseItems), etc.
       {
           Item item = new Item();
           item.X = i;
           i += 10;
           yield return item;
       }
    }
