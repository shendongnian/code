    public int Days
    {
        get
        {
            return EndDate.Subtract(StartDate).Days;
        }
    }
