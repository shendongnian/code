    private Style _buttonStyle;
    public Style ButtonStyle 
    { 
        get 
        {
            return _buttonStyle
        }
        set 
        { 
            if (!typeof(Button).IsAssignableFrom(value.TargetType))
            {
    	        throw new ArgumentException("The target type is expected to be Button");
            } 
            _buttonStyle = value;
        }; 
    }
