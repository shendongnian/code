    private int ReadWeekFromSession()
    {
        if (Session["week"] == null)
        {
            return 0;
        }
    
        int currentWeek = 0;
    
        if (int.TryParse(Session["week"].ToString(), out currentWeek))
        {
        }
    
        return currentWeek;
    }
