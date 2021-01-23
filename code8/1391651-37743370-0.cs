    string quarterInfo = "Q2(JUN) - 2016";
    DateTime monthDt;  // will be parsed to: 06/01/2016 00:00:00
    if (DateTime.TryParseExact(
        quarterInfo.Substring(quarterInfo.IndexOf('(') + 1), 
        "MMM) - yyyy",
        DateTimeFormatInfo.InvariantInfo,
        DateTimeStyles.None, 
        out monthDt))
    {
        int year = monthDt.Year;
        int quarter = (monthDt.Month + 2) / 3;
        Console.WriteLine("Q{0}-{1}", quarter, year);  // Q2-2016
    }
