    public string GetResultWbyYears()
    {
    	int year = DateTime.Now.Year;
    	using (var context = new DbEntity())
    	{
    		var result = (from hm in dbSet
                where hm.Isactive && !hm.Isdelete && hm.HolidayDate.Year == 2015
                orderby hm.HolidayDate ascending
                select new HolidayEntity {
                    HolidayDesc = x.HolidayDesc,
                    HolidayDate = x.HolidayDate,
                    Isactive = x.Isactive,
                    Isdelete = x.Isdelete,
                    HolidayId = x.HolidayId,
                    Zones = GetZonesWithSelectedForHolidays(x.HolidayId)
                }).ToList();
    	}
    }   
