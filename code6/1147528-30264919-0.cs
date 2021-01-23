    public int Day { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public DateTime Field
    {
        get { return new DateTime(Year, Month, Day); }
        set
        {
            Day = value.Day;
            Month = value.Month;
            Year = value.Year;
        }
    }
