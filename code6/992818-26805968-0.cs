    private double _lowerSplitValue;
     public double LowerSplitValue
            {
                get { return _lowerSplitValue; }
                set {
                  
                    
                    _lowerSplitValue = value;
                    OnPropertyChanged("LowerSplitValue");
                
    
    
                   
                }
            }
    
        public TimeSpan? TimePeriod
            {
                get { 
               
    
               return TimeSpan.FromSeconds(_lowerSplitValue);
    
    
                }
                set {
    
                    if (value != null) {
    
                        LowerSplitValue = value.Value.TotalSeconds;
                    
                    }
    
    
    
                    OnPropertyChanged("LowerTimeSpan");
                
                }
               
            }
