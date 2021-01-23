    private List<Item> itemList = ///etc.
    
    public List<Item> ItemList //binding to this
    {
        public get { return itemList.OrderByDescending(x => x.price); }
    }
