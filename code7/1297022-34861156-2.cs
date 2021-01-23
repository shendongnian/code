    ...
    _doubleClickCommand = new RelayCommand(OnDoubleClick);
    ...
        private RelayCommand _doubleClickCommand = null;
        private ApplicationViewModel _applicationViewModel;
        private void OnDoubleClick(object obj)
        {
            EmployeeDetailsViewModel selectedModel = obj as  EmployeeDetailsViewModel;
            _applicationViewModel.ChangeViewModel(selectedModel);
        }
        public ICommand DoubleClickCommand
        {
            get
            {
                return _doubleClickCommand;
            }
        }
