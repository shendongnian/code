    protected void DateRange(object sender, DayRenderEventArgs e)
    {
        DateTime rangeStart = new DateTime(2015, 7, 4);
        DateTime rangeEnd   = new DateTime(2016, 3, 15);
        if (e.Day.Date < rangeStart || e.Day.Date > rangeEnd)
        {
            e.Day.IsSelectable = false;
            e.Cell.ForeColor = System.Drawing.Color.Gray;
        }
    }
