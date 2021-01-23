    public class MainViewModel : INotifyPropertyChanged
    {
        // assuming you have the images
        private ObservableCollection<SomeItem> items = new ObservableCollection<SomeItem>
        {
            new SomeItem{ImagePath = "Images/a.jpg", Name= "sdfgsdfgsdfgdfsg"},
            new SomeItem{ImagePath = "Images/b.jpg", Name= "sdfgsdfgsdfgsdfg"},
            new SomeItem{ImagePath = "Images/c.jpg", Name= "sdfsdfgsdfgsdfgsdfgssdfg"},
        };
        private SomeItem selectedItem;
        public ObservableCollection<SomeItem> Items
        {
            get { return items; }
            set
            {
                if (Equals(value, items)) return;
                items = value;
                OnPropertyChanged("Items");
            }
        }
        public SomeItem SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (Equals(value, selectedItem)) return;
                selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
