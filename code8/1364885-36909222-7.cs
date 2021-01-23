    private string header1;
    public string Header1
    {
        get
        {
            return header1;
        }
        set
        {
            this.header1 = value;
            this.NotifyPropertyChanged("Header1");
        }
    }
