    public class ExampleViewModel : BaseViewModel
    {
        private readonly ObservableCollection<ExampleChildViewModel> _items;
        private readonly ListCollectionView _filteredItems;
    
        public ExampleViewModel()
        {
            _items = new RadObservableCollection<ExampleChildViewModel>();
            _filteredItems = new ListCollectionView(_items) {Filter = MyFilter};
    
            // todo - fill the items...
        }
    
        public IEnumerable Items { get { return _filteredItems; } }
    
        public bool IsScheduled
        {
            get { return isScheduled; }
            set
            {
                isScheduled = value;
                NotifyPropertyChanged();
    
                _filteredItems.Refresh();
            }
        }
    
        private bool MyFilter(object item)
        {
            ExampleChildViewModel thisItem = item as ExampleChildViewModel;
            if (thisItem == null)
            {
                return false;
            }
    
            if (thisItem.Name == "AwkwardCoder")
            {
                return true;
            }
    
            return false;
        }
    }
