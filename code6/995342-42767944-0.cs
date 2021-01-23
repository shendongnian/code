    private DateTime Date { get; set; }
    public DateTimeOffset DateOffset
    {
        get { return DateTime.SpecifyKind(Date, DateTimeKind.Utc); }
        set { Date = value.DateTime; }
    }
