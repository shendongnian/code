    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        if (IsSecondSaturdayInMonth(e.Day.Date))
        {
            e.Cell.ForeColor = System.Drawing.Color.Red;
        }
    }
