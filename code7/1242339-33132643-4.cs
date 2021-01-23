            private TabAndControlModel _selectedTabControlModel;
        private ICommand _checkCommand;
        private TabAndControlModel _currentControlContent;
        public ObservableCollection<TabAndControlModel> Controls { get; set; }
        public TabAndControlModel CurrentControlContent
        {
            get { return _currentControlContent; }
            set
            {
                _currentControlContent = value;
                OnPropertyChanged();
            }
        }
        public ICommand CheckCommand
        {
            get { return _checkCommand ?? (_checkCommand = new RelayCommand(Check)); }
        }
        private void Check()
        {
            var index = Controls.IndexOf(CurrentControlContent);
            var nextIndex = index + 1;
            if(nextIndex >= Controls.Count) return;
            CurrentControlContent = Controls[nextIndex];
            CurrentControlContent.TabIsEnabled = true;
        }
