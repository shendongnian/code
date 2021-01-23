    private double  _MyLimittedValue;
    public double  MyLimittedValue
      {
        get { return _MyLimittedValue; }
        set {
              if (value < 0.0 || value > 1.0) { value = 0.0; } 
              MyLimittedValue = value; 
            }
      }
