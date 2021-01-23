    public class ViewModelB : ViewModelBase
    {
        private bool _isAChecked;
        public bool IsAChecked
        {
            get
            {
                return _isAChecked;
            }
            set
            {
                _isAChecked = value;
                RaisePropertyChanged("IsAChecked");
            }
        }
    }
    public class Cmd : ICommand
    {
        ViewModelA _vmA;
        public Cmd(ViewModelA vmA)
        {
            _vmA = vmA;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public event EventHandler CanExecuteChanged;
        public void Execute(object parameter)
        {
            var vmB = new ViewModelB();
            vmB.IsAChecked = _vmA.IsChecked;
            // after that create ViewB, and set its DataContext to vmB
        }
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
