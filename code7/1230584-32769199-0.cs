    public StatiMacchina StatoMacchina { 
        get; 
        set{
           backingVariable = value;
           OnPropertyChanged();
        } 
    }
