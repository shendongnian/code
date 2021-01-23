    internal class MainWindowViewModel
    {
        private ICollectionView _categories;
        private ICollectionView _itemsWrapper;
        List<Item> _items => new List<Item>()
        {
            new Item()
            {
                Name = "First", ItemDetails = new List<Details>()
                {
                    new Details() {Category = "A", Value1 = 1, Value2 = 2, Value3 = 3},
                    new Details() {Category = "b", Value1 = 10, Value2 = 203, Value3 = 30},
                    new Details() {Category = "c", Value1 = 100, Value2 = 200, Value3 = 300},
                }
            },
                        new Item()
            {
                Name = "Second", ItemDetails = new List<Details>()
                {
                    new Details() {Category = "d", Value1 = 1, Value2 = 2, Value3 = 3},
                    new Details() {Category = "e", Value1 = 10, Value2 = 203, Value3 = 30},
                    new Details() {Category = "f", Value1 = 100, Value2 = 200, Value3 = 300},
                }
            }
        };
        public ICollectionView Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = CollectionViewSource.GetDefaultView(new ObservableCollection<string>() {"A", "b", "c", "d", "e", "f"});
                    _categories.CurrentChanged += (s, e) => Items.Refresh();
                }
                return _categories;
            }
        }
        public ICollectionView Items
        {
            get
            {
                if (_itemsWrapper == null)
                {
                    _itemsWrapper = CollectionViewSource.GetDefaultView(_items);
                    _itemsWrapper.Filter = sel =>
                    {
                        var item = sel as Item;
                        var toMatch = Categories.CurrentItem.ToString();
                        return item.ItemDetails.Any(i => i.Category == toMatch);
                    };
                }
                return _itemsWrapper;
            }
        }
    }
    public class Item
    {
        public string Name { get; set; }
        public List<Details> ItemDetails { get; set; }
    }
    public class Details
    {
        public string Category { get; set; }
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public int Value3 { get; set; }
    }
