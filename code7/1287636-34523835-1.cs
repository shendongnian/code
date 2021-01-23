    public string GetResultWbyYears()
    {
    	int year = DateTime.Now.Year;
    	using (var context = new DbEntity())
    	{
    		var result = (from hm in dbSet
                where hm.Isactive && !hm.Isdelete && hm.HolidayDate.Year == 2015
                orderby hm.HolidayDate ascending
                select hm).ToList();
    		
    		foreach (var item in result)
    			item.Zones = GetZonesWithSelectedForHolidays(item.HolidayId); 
    	}
    }    
