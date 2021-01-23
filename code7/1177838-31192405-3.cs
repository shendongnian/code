    public DateTime Date
    {
        get
        {
            return this.monthCalendar1.SelectionStart;
        }
        set
        {
            monthCalendar1.SelectionStart = value;
        }
    }
