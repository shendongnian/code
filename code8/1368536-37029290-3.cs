    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            for (int i = 0; i < 100; i++)
            {
                MyCollection.Add(new UseCase { UsecaseName = "name " + i, IsSelected = false });
            }
            MyCommand = new RelayCommand(MyCommandAction);
        }
        private ObservableCollection<UseCase> myCollection = new ObservableCollection<UseCase>();
        public ObservableCollection<UseCase> MyCollection
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
        public RelayCommand MyCommand { get; set; }
        private  void MyCommandAction(object obj)
        {
            foreach (var item in MyCollection)
            {
                item.IsSelected = (bool)obj;
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
    public class UseCase : INotifyPropertyChanged
    {
        public string UsecaseName { get; set; }
        private bool _isSelected;
        public bool IsSelected
        {
            get
            {
                return _isSelected;
            }
            set
            {
                _isSelected = value;
                NotifyPropertyChanged("IsSelected");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
