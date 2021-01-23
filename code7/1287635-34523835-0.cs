    public string GetResultWbyYears()
    {
    	int year = DateTime.Now.Year;
    	using (var context = new DbEntity())
    	{
    		var result = context.HolidayMasters
    			.Where(hm => hm.Isactive && !hm.Isdelete && hm.HolidayDate.Year == year)
    			.OrderBy(hm => hm.HolidayDate)
    			.ToList();
    		
    		foreach (var item in result)
    			item.Zones = GetZonesWithSelectedForHolidays(item.HolidayId); 
    	}
    }
