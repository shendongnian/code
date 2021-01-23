    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Excel = Microsoft.Office.Interop.Excel;
    namespace MyNamespace
    {
	    internal sealed class DateFormatComponentCodes
	    {
		    private readonly char year;
		    private readonly char month;
		    private readonly char day;
            // Constructs the object based on the system localization.
	    	public DateFormatComponentCodes()
		    {
			    DateTimeFormatInfo dateTimeFormatInfo = CultureInfo.CurrentCulture.DateTimeFormat;
			    var yearMonth = new HashSet<char>(new HashSet<char>(dateTimeFormatInfo.YearMonthPattern.ToCharArray()).Where(c => char.IsLetter(c)));
			    var monthDay = new HashSet<char>(new HashSet<char>(dateTimeFormatInfo.MonthDayPattern.ToCharArray()).Where(c => char.IsLetter(c)));
			    var monthHashSet = new HashSet<char>(yearMonth);
			    monthHashSet.IntersectWith(monthDay);
			    this.month = monthHashSet.First();
			    yearMonth.ExceptWith(monthHashSet);
			    this.year = yearMonth.First();
			    monthDay.ExceptWith(monthHashSet);
			    this.day = monthDay.First();
		    }
            // Constructs the object based on the Excel localization.
		    public DateFormatComponentCodes(Excel.Application application)
		    {
			    this.year = application.International[Excel.XlApplicationInternational.xlYearCode].ToString()[0];
			    this.month = application.International[Excel.XlApplicationInternational.xlMonthCode].ToString()[0];
			    this.day = application.International[Excel.XlApplicationInternational.xlDayCode].ToString()[0];
		    }
		    public char Year
		    {
			    get
			    {
				    return this.year;
			    }
		    }
		    public char Month
		    {
			    get
			    {
				    return this.month;
			    }
		    }
		    public char Day
		    {
			    get
			    {
				    return this.day;
			    }
		    }
	    }
    }
