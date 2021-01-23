    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (ListDates != null )
        {
            if (ListDates.Contains(e.Day.Date))
            {
                e.Cell.CssClass = "highlight";
            }
    
            if (ListDates.Contains(Calendar1.SelectedDate) && e.Day.Date == Calendar1.SelectedDate)
            {
                e.Cell.CssClass = "newHighlight";
            }
        }
    }
