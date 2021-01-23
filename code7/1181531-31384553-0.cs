    using System;
    using NodaTime;
    					
    public class Program
    {
    	public static void Main()
    	{
    		LocalDate start = new LocalDate(2010, 11, 20);
    		LocalDate end = new LocalDate(2015, 7, 13);
    		
    		Period period = Period.Between(start, end, 
    									   PeriodUnits.Months | PeriodUnits.Years);
    		
    		Console.WriteLine("{0} - {1}", period.Months, period.Years); // 7 - 4
    	}
    }
