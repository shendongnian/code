    public class BindingViewModel : ViewModelBase
    {
        public BindingViewModel()
        {
            Items = new ObservableCollection<int>();
            Items.CollectionChanged += Items_CollectionChanged;
        }
        public void Add(int value)
        {
            Items.Add(value);
        }
        private void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Items = new ObservableCollection<int>(Items.OrderBy(x => x));
            Items.CollectionChanged += Items_CollectionChanged;
        }
        private ObservableCollection<int> _items;
        public ObservableCollection<int> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }
    }
