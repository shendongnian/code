    public void ValidateValue(float value)
    {
        if (value != VALID_VALUE)
        {
            throw new ArgumentException("Invalid value", "value"); 
        }
    }
