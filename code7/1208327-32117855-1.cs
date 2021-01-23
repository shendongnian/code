        private object _currentViewModel;
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }
        public void SetViewModel(ContentControlViewModel viewModel)
        {
            switch (viewModel)
            {
                    case ContentControlViewModel.MainViewModel:
                    CurrentViewModel = new MainViewModel();
                    break;
            }
        }
