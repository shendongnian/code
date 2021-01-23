        private ICommand _command;
        public ObservableCollection<ClicableItemsModel> Strings { get; set; }
        public ICommand Command
        {
            get { return _command ?? (_command = new RelayCommand<object>(MethodOnCommmand)); }
        }
        private void MethodOnCommmand(object obj)
        {
        }
