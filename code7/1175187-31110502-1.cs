    public class ItemModel
    {
        public int ItemId { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
    }
    public class ItemListViewModel
    {
        public IList<ItemModel> ItemList { get; set; }
    }
