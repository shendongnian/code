	public enum Intervals
	{
		Days,
		Months,
		Years
	}
	public static int DateDiff(Intervals eInterval, System.DateTime dtInit, System.DateTime dtEnd)
	{
		if (dtEnd < dtInit)
			throw new ArithmeticException("Init date should be previous to End date.");
		switch (eInterval) {
			case Intervals.Days:
				return (dtEnd.AddDays - dtInit).TotalDays;
			case Intervals.Months:
				return ((dtEnd.Year - dtInit.Year) * 12) + dtEnd.Month - dtInit.Month;
			case Intervals.Years:
				return dtEnd.Year - dtInit.Year;
			default:
				throw new ArgumentException("Incorrect interval code.");
		}
	}
