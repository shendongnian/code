    public prepateTreatmentState PrepareState
    {
      get { return _prepareState; }
        set { 
            if(value != _prepareState)
            {
                _prepareState = value;
                RaisePropertyChanged("PrepareState");
            }
        }
