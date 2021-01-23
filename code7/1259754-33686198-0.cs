    public void setMonth()
    {
        if (value > 0 && value <= 12)
            month = value; // <-- value is unknown
        else
            throw new ArgumentOutOfRangeException("Month", value, "Month must be 1-12");
    }
