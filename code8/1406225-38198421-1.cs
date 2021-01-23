    private string _Inputed;
    public string Inputed
    {
        get { return _Inputed; }
        set 
        {
            if(Equals(_Inputed, value) == true) return;
            _Inputed = value;
            this.OnPropertyChanged(nameof(this.Inputed));
        }
    }
    void threadFunc()
    {
        try
        {
            while (threadRunning)
            {
                plc.Read();
                this.Inputed = plc.InputImage[1].ToString();
            }
        }
        catch (ThreadAbortException)
        {
        }
    }
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string name)
    {
        PropertyChangedEventHandler handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
