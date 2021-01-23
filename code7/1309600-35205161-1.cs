        public ICommand NewTimmerCommand
        {
            get { return _newTimmerCommand; }
            set
            {
                _newTimmerCommand = value;
                OnPropertyChanged("NewTimmerCommand");
            }
        }
