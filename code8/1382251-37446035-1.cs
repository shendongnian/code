    private string _StatusIconPath;
    
    public string StatusIconPath 
    {
       get { return _StatusIconPath; }
       set
           {
           _StatusIconPath = value;
           PropertyChanged("StatusIconPath");
           }
    }
