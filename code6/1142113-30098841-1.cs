     RelayCommand _okCommand;
    public ICommand okCommand
    {
        get
        {
            if (_ok == null)
            {
                _ok= new RelayCommand(param => this.Show());
            }
            return _ok;
        }
    }
    private void Show()
    {
        if (Parent != null)
        {
            // Handle ok logic Here
        }
    }
