    public double LightningImpulseVoltage
    {
        get { return _LightningImpulseVoltage; }
        set 
        { 
            SetProperty(ref _LightningImpulseVoltage, value);
            if (OnLightningImpulseVoltage != null)
                OnLightningImpulseVoltage();
            OnPropertyChanged("IsEnabled");
        }
    }
