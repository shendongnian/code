    public static DateTime MyMonday(DateTime date)
    {
        var myMon = date;
        while (myMon.DayOfWeek != System.DayOfWeek.Monday) {
            myMon = myMon.AddDays(-1);
        }
        return myMon;
    }
