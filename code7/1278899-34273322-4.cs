    public ICommand CloseCommand
        {
            get
            {
                return new DelegateCommand((obj)=>CloseMethod(obj));
            }
        }
