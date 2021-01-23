        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(
                        param => save(),
                        param => IsValid((DependencyObject)param) // actually the type of param is MyUserControl
                    );
                }
                return _saveCommand;
            }
        }
