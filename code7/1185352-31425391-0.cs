    // in Pump_event Class
    public static event Action<GameObject> OnDamagedValueChanged;
    private bool _damaged;
    public bool Damaged
    {
        get { return _damaged;}
        set 
        { 
            _damaged = value;
            if(_damaged)
            {
                  if(OnDamagedValueChanged != null)
                      OnDamagedValueChanged(gameObject);  
            }
        } 
    }
