    public MyModel Model
    {
        get { return _model; }
        set
        {
            if (_model != null)
                _model.PropertyChanged -= OnModelPropertyChanged;
    
            _model = value;
    
            if (_model != null
                _model.PropertyChanged += OnModelPropertyChanged;
       
            NotifyPropertyChange(() => Model);
         } 
    }
