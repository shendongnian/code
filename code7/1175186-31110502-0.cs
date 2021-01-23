    public class ItemModel
    {
        public int ItemId { get; set; }
        public string Type { get; set; }
    }
    public class ItemListViewModel
    {
        public IList<ItemModel> ItemList { get; set; }
    }
