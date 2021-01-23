        private ViewModelBase _Current_ViewModel;
        public ViewModelBase Current_ViewModel
        {
            get { return _Current_ViewModel; }
            set {
                _Current_ViewModel = value;
                // the Constructor of the ViewModel never gets called more that once on App Start 
                // so we have to implement/raise our own event when changing from one View to another.
                if (Current_ViewModel != null)
                    Current_ViewModel.InitializeFunction(); // InitializeFunction will fire the event in this ViewModel, we can now initialise the properties.
                OnPropertyChanged("Current_ViewModel"); }
        }
