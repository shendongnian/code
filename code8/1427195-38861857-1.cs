    public string ButtonText
    {
        get
        {
            return (string)GetValue(TextProperty);
        }
        set
        {
            SetValue(TextProperty, value);
        }
    }
    
    public Symbol Icon
    {
       get
       {
           return (Symbol)GetValue(SymbolIconProperty);
       }
       set
       {
           SetValue(SymbolIconProperty, value);
       }
    }
    
