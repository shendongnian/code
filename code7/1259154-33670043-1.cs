    public void SetGender(int value)
    {
        this.isFemale = (value == 2); 
        // Note: Since 1 is not handled this might be causing your problem
        // In your example when value == 1, nothing happens.
    }
