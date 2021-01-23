       public class TileReTemplateTestViewModel:Screen
    {
        private ObservableCollection<ItemTypeWrapper> _items;
        public TileReTemplateTestViewModel()
        {
            _items = new ObservableCollection<ItemTypeWrapper>(GetInitializedItemCollection());
            DisplayName = "Test";
        }
        private List<ItemTypeWrapper> GetInitializedItemCollection()
        {
            var doubles = new List<ItemType>
            {
                ItemType.Mail, ItemType.Weather
            };
            var items = Enum.GetValues(typeof (ItemType))
                .OfType<ItemType>()
                .Select(type => new ItemTypeWrapper {ItemType = type}).ToList();
            items.ForEach(wrapper =>
            {
                wrapper.IsDouble = doubles.Contains(wrapper.ItemType);
            });
            return items;
        }
        public ObservableCollection<ItemTypeWrapper> Items
        {
            get { return _items; }
        }
    }
    public class ItemTypeWrapper:PropertyChangedBase
    {
        private ItemType _itemType;
        private bool _isDouble;
        public ItemType ItemType
        {
            get { return _itemType; }
            set
            {
                _itemType = value;
                NotifyOfPropertyChange(() => ItemType);
            }
        }
        public bool IsDouble
        {
            get { return _isDouble; }
            set
            {
                _isDouble = value;
                NotifyOfPropertyChange(()=>IsDouble);
            }
        }
    }
    public enum ItemType
    {
        Mail,
        Market,
        Contacts,
        Weather,
    }
