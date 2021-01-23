    [DataType(DataType.Date)]
    private DateTime? date;
    public DateTime Date
    {
        get { return date ?? DateTime.Today; }
        set { date = value; }
    }
    [DataType(DataType.Time)]
    private DateTime? time;
    public DateTime time
    {
        get { return time ?? DateTime.Now; }
        set { time = value; }
    }
