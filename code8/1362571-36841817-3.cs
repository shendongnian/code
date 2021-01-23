    public ActionResult Index(int? value)
    {
        int weekStart = 0;
    
        if (!value.HasValue)
        {
            weekStart = ReadWeekFromSession();
        }
        else
        {
            IncrementWeeks(value.Value);
            weekStart = ReadWeekFromSession();
        }
        
    	// Rest of controller code....    
    }
