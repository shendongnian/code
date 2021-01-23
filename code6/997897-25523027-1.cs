        using System;
        using System.Text.RegularExpressions;
        
        public class FinancialPeriod
        {
    	const string PATTERN = @"^([0-9]{4})\s?-\s?([0-9]{4})$";
    	
    	public FinancialPeriod()
    	{
    		this.Year = DateTime.Today.Year;
    		
    		if (DateTime.Today.Month > 3)
    		{
    			this.From = new DateTime(Year, 4, 1);
    			this.To = new DateTime(Year + 1, 3, DaysInMarch(Year + 1));
    		}
    		else
    		{
    			this.From = new DateTime(Year - 1, 4, 1);
    			this.To = new DateTime(Year, 3, DaysInMarch(Year));
    		}
    	}
    	
    	public FinancialPeriod(string period) : this()
    	{
    		
    		Match m = Regex.Match(period, PATTERN);
    		this.From = new DateTime(Int32.Parse(m.Groups[1].Value), 4, 1);
    		this.To = new DateTime(Int32.Parse(m.Groups[2].Value), 3, DaysInMarch(Int32.Parse(m.Groups[2].Value)));
    	}
    	
    	private DateTime From { get; set; }
    	private DateTime To { get; set; }
    	private int Year { get; set; }
    	
    	public string period
    	{
    		get
    		{
    			return string.Format("{0} - {1}", this.From.Year, this.To.Year);
    		}
    	}
    	
    	private int DaysInMarch(int yr)
    	{
    		return DateTime.DaysInMonth(yr, 03);
    	}
    }
