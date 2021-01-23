    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<string> _items;
        private string _selectedItem;
        public MainViewModel()
        {
            Items = new ObservableCollection<string>(new[] { "a", "b", "c" });
        }
        public ObservableCollection<string> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(); }
        }
        public string SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; RaisePropertyChanged(); }
        }
    }
