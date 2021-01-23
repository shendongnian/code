    public decimal TargetDecimal
    {
        get { return _TargetDecimal; }
        set { _TargetDecimal = value; 
            OnPropertyChanged("TargetDecimal"); 
            OnPropertyChanged("TargetValueTruncated"); }
    }
    
    // No error checking done for example
    public string TargetValueTruncated
    {
      get { return Regex.Match(_TargetDecimal.ToString(), 
                               @"\d+\.\d\d\d").Value ; }
    }
