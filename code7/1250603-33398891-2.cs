    private ObservableCollection<ClientFilter> clientFilters;
    public IEnumerable<ClientFilter> ClientFilters
    {
        get
        {
            if (this.clientFilters == null)
            {
                this.clientFilters = new ObservableCollection<ClientFilter>();
            }
            return this.clientFilters;
        }
        set
        {
            if (this.clientFilters == null)
            {
                this.clientFilters = new ObservableCollection<ClientFilter>();
            }
            SetObservableValues<ClientFilter>(this.clientFilters, value);
        }
    }
