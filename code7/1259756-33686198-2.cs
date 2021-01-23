    public int month; // shouldn't be public
    private int Month 
    { 
        get { return month; }
        set 
        {
            if (value > 0 && value <= 12)
                month = value; // <-- here, value does exist
            else
                throw new ArgumentOutOfRangeException("Month", value, "Month must be 1-12");    
        }
    }
