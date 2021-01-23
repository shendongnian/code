    void OnEnable()    
    {
        Pump_event.OnDamagedValueChanged += HandleOnDamagedValueChanged;
    }
    void OnDisable()    
    {
        Pump_event.OnDamagedValueChanged -= HandleOnDamagedValueChanged;
    }   
    void HandleOnDamagedValueChanged(GameObject obj)
    {
        if (!BrokenMotor_list.Contains (obj))  
        {
            BrokenMotor_list.Add (obj);
        }
    } 
