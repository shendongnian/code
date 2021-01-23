    public sometype Field;
    
    private sometype _previousValueOfField;
    
    public void Awake()
    {
        _previousValueOfField = Field;
    }
    
    public void Update()
    {
        if(Field != _previousValueOfField)
        {
            _previousValueOfField = Field;
            // Execute some logic regarding the change of the field there        
        }
    }
