        public class MainViewModel:BaseObservableObject
    {
        public MainViewModel()
        {
            ObservableCollection = new ObservableCollection<Empclass>(new List<Empclass>
            {
                new Empclass{abc=2, pqr = 3},
                new Empclass{abc=5, pqr = 7},
                new Empclass{abc=11, pqr = 13},
                new Empclass{abc=17, pqr = 19}
            });
        }
        public ObservableCollection<Empclass> ObservableCollection { get; set; }
    }
    public class Empclass : BaseObservableObject
    {
        private ICommand _command;
        private int _abc;
        private int _pqr;
        public ICommand Command
        {
            get { return _command ?? (_command = new RelayCommand(myfunction)); }
        }
        public int abc
        {
            get { return _abc; }
            set
            {
                _abc = value;
                OnPropertyChanged("abc");
            }
        }
        public int pqr
        {
            get { return _pqr; }
            set
            {
                _pqr = value;
                OnPropertyChanged("pqr");
            }
        }
        private void myfunction()
        {
            //add you command logic here
            var temp = pqr;
            pqr = abc;
            abc = temp;
        }
    }
