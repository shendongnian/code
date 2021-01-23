    public static class DateTimeExtensions
    {
    	public static DateTime LastDayOfMonth(this DateTime date)
    	{
    		DateTime EOM = new DateTime(
    			date.Year,date.Month,
    			DateTime.DaysInMonth(
    				date.Year,
    				date.Month
    			)
    		);
                
    		return EOM;
    	}
    }
