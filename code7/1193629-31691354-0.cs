    using System.Linq;
    
    class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Items = new ObservableCollection<TestItem>();
        }
    
        public ObservableCollection<TestItem> Items { get; private set; }
        //public ObservableCollection<TestItem> ItemsRead { get; private set; } // key point
        public IEnumerable<TestItem> ItemsRead
        {
    		get
    		{
    			IEnumerable<TestItem> itemsRead = from item in Items
    										  where item.IsRead
    										  select item;
    			return itemsRead;
    		}
        }
    
    
        private void RefreshItems()
        {
            // data manipulation - on both collections?
        }
    
        // ...
    }
