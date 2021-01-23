	static DateTime mExpiryDate = DateTime.Parse("09/29/2015");
	public static void Main()
	{
		var result = string.Empty;
		var noticeDate = DateTime.Parse("09/05/2015");
		mExpiration_Compute(ref result, noticeDate);
		Console.WriteLine(result);
	}
	public static void mExpiration_Compute(ref string result, DateTime noticeDate)
	{
		DateTime a = noticeDate;
		DateTime b = mExpiryDate;
		TimeSpan ts = b.Subtract(a);
		result = string.Format("You have {0} days to expiry date.", ts.Days);
	}
