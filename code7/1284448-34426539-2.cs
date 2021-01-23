    namespace WpfApplication3
    {
        public class DataContext
        {
            public ObservableCollection<Item> Items { get; private set; }
            public ICommand AddItem { get; private set; }
    
            public DataContext()
            {
                Items = new ObservableCollection<Item>
                {
                    new Item
                    {
                        Value = "test"
                    }
                };
                AddItem = new RelayCommand(() =>
                {
                    Items.Add(new Item
                    {
                        Value = "new item"
                    });
                }, () => true);
            }
        }
    
        public class Item
        {
            public string Value { get; set; }
        }
    }
