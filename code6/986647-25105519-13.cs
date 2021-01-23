    picker.DataBindings.Add("Value", this, "EventDate");
    ...
    private DateTime eventDate;
    public DateTime EventDate
    {
        get { return eventDate; }
        set
        {
            eventDate = value;
            eventDate.Kind = DateTimeKind.Local;
        }
    }
