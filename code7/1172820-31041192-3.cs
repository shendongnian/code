    public class ItemContainer : INotifyPropertyChanged
    {
        private ObservableCollection<string> _NameTab;
        public ObservableCollection<string> NameTab
        {
            get { return _NameTab; }
            set
            {
                _NameTab = value;
                PropertyChanged(this, new PropertyChangedEventArgs("NameTab"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
