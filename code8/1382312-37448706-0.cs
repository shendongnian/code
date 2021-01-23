    private static string ToMediumDateString(string _date)
    {
        string yearPortion = _date.Substring(0, 4);
        int monthNum = Convert.ToInt32(_date.Substring(4, 2));
        int dayNum = Convert.ToInt32(_date.Substring(6, 2));
        string monthName = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNum);
        return String.Format("{0} {1}, {2}", monthName, dayNum, yearPortion);
    }
