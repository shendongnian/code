        ICommand _command;
        public RelayCommand ChangePageCommand
        {
            get
            {
                return _command ?? (_command = new RelayCommand(p => ChangeViewModel((BaseViewModel) p), x =>
                {
                    x is BaseViewModel;
                }));
            }
        }
