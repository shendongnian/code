    using System;
    using System.Text.RegularExpressions;
    
    public class FinancialPeriod
    {
    	const string PATTERN = @"^([0-9]{4})\s?-\s?([0-9]{4})$";
    	
    	public FinancialPeriod()
    	{
    		if (DateTime.Today.Month > 3)
    		{
    			this.From = new DateTime(DateTime.Today.Year, 4, 1);
    			this.To = new DateTime(DateTime.Today.Year + 1, 3, 31);
    		}
    		else
    		{
    			this.From = new DateTime(DateTime.Today.Year - 1, 4, 1);
    			this.To = new DateTime(DateTime.Today.Year, 3, 31);
    		}
    	}
    	
    	public FinancialPeriod(string period)
    	{
    		
    		Match m = Regex.Match(period, PATTERN);
    		this.From = new DateTime(Int32.Parse(m.Groups[1].Value), 4, 1);
    		this.To = new DateTime(Int32.Parse(m.Groups[2].Value), 3, 31);
    	}
    	
    	private DateTime From { get; set; }
    	private DateTime To { get; set; }
    	
    	public string period
    	{
    		get
    		{
    			return string.Format("{0} - {1}", this.From.Year, this.To.Year);
    		}
    	}
    }
