        public ObservableCollection<string> Strings { get; set; }
        public ICommand Command
        {
            get { return _command ?? (_command = new RelayCommand<object>(MethodOnCommmand)); }
        }
        private void MethodOnCommmand(object obj)
        {
        }
