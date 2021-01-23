        class MainViewModel : INotifyPropertyChanged
    {
        private bool _isChecked;
        public bool IsChecked
        {
            get { return _isChecked; }
            set
            {
                _isChecked = value;
                OnPropertyChanged();
            }
        }
        private RelayCommand _radioButtonCheckedCommand;
        public RelayCommand RadioButtonCheckedCommand
        {
            get
            {
                return _radioButtonCheckedCommand ??
                       (_radioButtonCheckedCommand = new RelayCommand(() => IsChecked = true));
            }
        }
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
