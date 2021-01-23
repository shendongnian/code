    public class Item : INotifyPropertyChanged
    {
        private string _name = "";
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] String propName = null)
        {
            PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(propName));
        }
    }
    public class ItemSubClass : Item
    {
        #region Category Property
        private String _category = default(String);
        public String Category
        {
            get { return _category; }
            set
            {
                if (value != _category)
                {
                    _category = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion Category Property
    }
    public class ViewModel
    {
        public ViewModel()
        {
            Items.Add(new Item { Name="Alan"});
            Items.Add(new ItemSubClass { Name = "Bob", Category = "Whatever" });
            Items.Add(new Item { Name = "Charlie" });
        }
        public ObservableCollection<Item> Items { get; private set; }
            = new ObservableCollection<Item>();
    }
