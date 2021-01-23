    private void IncrementWeeks(int weeks)
    {
        if (Session["week"] == null)
        {
            Session["week"] = week.WeekNum();
            return;
        }
        int currentWeek = 0;
    
        if (int.TryParse(Session["week"].ToString(), out currentWeek))
        {
            Session["week"] = (currentWeek + weeks).ToString();
        }
    }
