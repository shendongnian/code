    public  DateTime AddDaysToToday(int days)
    {
        return DateTime.Now.AddDays(days);
    }
    DateTime today = AddDaysToToday(0);
    DateTime todayPlusSeven = AddDaysToToday(7);
    DateTime todayMinusSeven = AddDaysToToday(-7);
