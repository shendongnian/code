    public SomeClass(VolatileBoolWrapper value)
    {
       this.value = value;              
    }
    
    public void OnNext(object someUpdatedValue)
    {
       value.SetValue(true);
    }
