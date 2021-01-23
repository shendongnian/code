    private List<Item> itemList = ///etc.
    
    public List<Item> ItemList
    {
        public get { return itemList.OrderByDescending(x => x.price); }
    }
