        private ViewModelBase _Current_ViewModel;
        public ViewModelBase Current_ViewModel
        {
            get { return _Current_ViewModel; }
            set {
                if (Current_ViewModel != null)
                    Current_ViewModel.RaiseDeActivate(SendObject);
                _Current_ViewModel = value;
                if (Current_ViewModel != null)
                    Current_ViewModel.RaiseActivate(SendObject);
                OnPropertyChanged("Current_ViewModel"); }
        }
