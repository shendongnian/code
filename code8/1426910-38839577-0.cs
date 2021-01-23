    string strDate = "09-Aug-2016";
	DateTime datDate;
	if (DateTime.TryParseExact(strDate, new string[]
	{
	"dd-MMM-yyyy"
	}
	, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out datDate))
	{
		Console.WriteLine(datDate.ToString("yyyy/MM/dd"));
	}
	else
	{
		//Error in datetime format
	}
