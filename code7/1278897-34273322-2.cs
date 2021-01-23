    public ICommand CloseSessionCommand
        {
            get
            {
                return new DelegateCommand((obj)=>CloseSelectedSession(obj));
            }
        }
