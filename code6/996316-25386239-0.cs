    private bool gridBusy;
    public bool GridBusy
    {
        get { return this.gridBusy; }
        set
        {
            this.gridBusy = value;
            this.RaisePropertyChanged("GridBusy");
        }
    }
