    public class MainViewModel : ViewModelBase
    {
        public MenuViewModel MenuVM { get; set; }
        public StatusBarViewModel StatusBarVM { get; set; }
        public MainViewModel()
        {
            MenuVM = new MenuViewModel();
            StatusBarVM = new StatusBarViewModel();
            StatusBarVM.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Property2" && MenuVM != null)
                    MenuVM.RaisePropertyChanged("Property1");
            };
        }
    }
    public class MenuViewModel : INotifyPropertyChanged
    {
        private string _property1;
        public string Property1
        {
            get { return _property1; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        internal void RaisePropertyChanged(string p)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(p));
        }
    }
    public class StatusBarViewModel : INotifyPropertyChanged
    {
        private string _property2;
        public string Property2
        {
            get { return _property2; }
            set
            {
                _property2 = value;
                RaisePropertyChanged("Property2");
            }
        }
        private void RaisePropertyChanged(string p)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(p));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
