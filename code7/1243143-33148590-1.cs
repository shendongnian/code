    protected void CalendarDRender(object sender, System.Web.UI.WebControls.DayRenderEventArgs e)
    {
        bool dayHasEvent = table.AsEnumerable()
            .Any(row => row.Field<DateTime>("caldate").Date == e.Day.Date);
        if (dayHasEvent)
            e.Cell.BackColor = Color.PaleVioletRed;
    }
