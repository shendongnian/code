    private int _MachineID;
    public int MachineID
    {
        get { return _MachineID; }
        set
        {
            _MachineID = value;
            OnNotifyPropertyChanged("MachineID");
        }
    }
