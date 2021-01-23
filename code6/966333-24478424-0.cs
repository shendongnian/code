    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (e.Day.Date.DayOfWeek.ToString() == "Saturday" && e.Day.Date.Day > 7)
        {
            e.Cell.ForeColor = System.Drawing.Color.Red;
        }
    }
