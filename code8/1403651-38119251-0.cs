    public MyClient SelectedClient
    {
        get
        {
            return _selectedClient;
        }
        set
        {
            if (value != _selectedClient)
            {
                _selectedClient = value;
                ClientSelected();
                NotifyPropertyChanged("SelectedClient");
            }
        }
    }
