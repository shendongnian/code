    private double _someVal;
    
    public double SomeVal
    {
    	get { return _someVal; }
    	set { _someVal = value; NotifyPropertyChanged( "SomeVal" ); }
    }
