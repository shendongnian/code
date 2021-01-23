    public ICommand CmdWindowClosing
        {
            get
            {
                return new RelayCommand<CancelEventArgs>(
                    (args) =>{
                        });
            }
        }
