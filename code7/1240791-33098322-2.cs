    private List<Client_Type> client_type_list;
    public List<Client_Type> Client_type_list
    {
        get { return client_type_list; }
        set
        {
            client_type_list = value;
            RaisePropertyChanged("Client_type_list");
        }
    }
    public void LoadExecute()
    {
        Client_type_list = ServerPxy.GetClientTypes();
    }
