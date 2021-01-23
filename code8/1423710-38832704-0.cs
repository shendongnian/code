    public class JumpListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Item> _allItems;
        private List<string> _alphabetList;
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        public JumpListViewModel()
        {
            AllItems = new ObservableCollection<Item>(new List<Item> { new Item { MyText = "1" }, new Item { MyText = "2" }, new Item { MyText = "3" } });
            AlphabetList = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().Select(x => x.ToString()).ToList();
        }
        public ObservableCollection<Item> AllItems
        {
            get { return _allItems; }
            set
            {
                _allItems = value;
                OnPropertyChanged();
            }
        }
        public List<string> AlphabetList
        {
            get { return _alphabetList; }
            set
            {
                _alphabetList = value;
                OnPropertyChanged();
            }
        }
    }
