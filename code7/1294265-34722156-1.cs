     public class ParentViewModel : INotifyPropertyChanged
    {
        public ParentViewModel()
        {
            MyList = new List<string>();
            MyList.Add("1");
            MyList.Add("2");
            MyList.Add("3");
            MyList.Add("4");
            MyList.Add("5");
            MyList.Add("6");
            RemoveButtonCommand = new RelayCommand(param => this.RemoveCommandAction(param), param => this.CanExecuteRemoveButtonCommand(param));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private List<string> myList;
        public List<string> MyList
        {
            get { return myList; }
            set 
            { 
                myList = value;
                OnPropertyChanged("MyList");
            }
        }
        public RelayCommand RemoveButtonCommand { get; set; }
        public void RemoveCommandAction(object param)
        {
            MyList.Remove((string)param);
            MyList = new List<string>(MyList);
        }
        public bool CanExecuteRemoveButtonCommand(object param)
        {
            return MyList[MyList.Count - 1] == ((string)param);
        }
    }
