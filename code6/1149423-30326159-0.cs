    public enum Seasons
    {
	    Spring,
    	Summer,
	    Autumn,
	    Winter
    }  
    public class SeasonDates
    {
	    public static DateTime SpringStart(int year)
    	{
		    return new DateTime(year, 3, 20);
    	}
	    public static DateTime SummerStart(int year)
    	{
	    	return new DateTime(year, 6, 21);
    	}
	    public static DateTime AutumnStart(int year)
    	{
	    	return new DateTime(year, 9, 23);
    	}
	    public static DateTime WinterStart(int year)
    	{
	    	return new DateTime(year, 12, 22);
    	}
    }
    public static class MyExtensions
    {	
    	public static Seasons GetSeason(this DateTime date)
	    {
		    var result = Seasons.Winter;
  		
    		if (date >= SeasonDates.SpringStart(date.Year) && date < SeasonDates.WinterStart(date.Year))
	    		result = Seasons.Autumn;
    		else if (date >= SeasonDates.SummerStart(date.Year))
	    		result = Seasons.Summer;
    		else if (date >= SeasonDates.SpringStart(date.Year))
	    		result = Seasons.Spring;
  		
    		return result;
    	}
    }
