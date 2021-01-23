    picker.DataBindings.Add("Value", this, "EventDate");
    ...
    private DateTime eventDate;
    public DateTime EventDate
    {
        get { return eventDate; }
        set
        {
            // Create a copy of DateTime and set Kind to Local since Kind is readonly
            eventDate = new DateTime(value.Ticks, DateTimeKind.Local);
        }
    }
