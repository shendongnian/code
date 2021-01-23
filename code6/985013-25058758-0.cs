    public class ViewModelA : ViewModelBase
    {
        public ViewModelA()
        {
            _nextCommand = new Cmd(this);
        }
        public ICommand NextCommand { get { return _nextCommand; } }
        
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                RaisePropertyChanged("IsChecked");
            }
        }
        private ICommand _nextCommand;
        private bool _isChecked;
    }
