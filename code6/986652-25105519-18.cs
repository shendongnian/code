    picker.DataBindings.Add("Value", this, "EventDate");
    ...
    private DateTimeOffset eventDate;
    public DateTime EventDate
    {
        get { return eventDate.LocalDateTime; }
        set { eventDate = new DateTimeOffset(value); }
    }
