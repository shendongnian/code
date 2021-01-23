    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            for (int i = 0; i < 10; i++)
            {
                MyCollection.Add("Item " + i);
            }
            MySelectedItem = "Item 2";
        }
        private ObservableCollection<string> myCollection = new ObservableCollection<string>();
        public ObservableCollection<string> MyCollection
        {
            get
            {
                return myCollection;
            }
            set
            {
                myCollection = value;
                NotifyPropertyChanged("MyCollection");
            }
        }
        private string _mySelectedItem;
        public string MySelectedItem
        {
            get
            {
                return _mySelectedItem;
            }
            set
            {
                _mySelectedItem = value;
                NotifyPropertyChanged("MySelectedItem");
            }
        }
        //NotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
