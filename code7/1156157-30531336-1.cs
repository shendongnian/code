    Timer pollTimer = new System.Timers.Timer(1000); // fires every second
    public void Initialize()
    {
       // subscribe the PollTemperature function to the Elapsed event.
       pollTimer.Elapsed += PollTemperature;
       // Enable the periodic polling
       pollTimer.Enabled = true;
    }
 
    private float _Value;
    public float Value
    {
        get { return _Value; }
        set
        { 
           if(_value != value)
           {
              _value = value
           }
        }
     }
     public decimal GetTemperature()
     {
        // get the temperature of the cpu sensor here
        float yourTemperature = resultsOfYourLogic;
        return yourTemperature;
     }
     void PollTemperature(Object source, ElapsedEventArgs e)
     {
        Value = GetTemperature();
        this.Invalidate();
        this.Update();
     } 
