    static DateTime InitialDate = new DateTime(2012, 06, 25);
    private static int PayPeriod(DateTime inputDate)
    {
        int periodStartDay = (inputDate - InitialDate).Days % 14 + 1;
        int periodStartMonth = 07;
        int periodStartYear = inputDate.Month >= 7 ? inputDate.Year : inputDate.Year - 1;
        DateTime periodStartDate = new DateTime(periodStartYear, periodStartMonth, periodStartDay);
        int payPeriod = (inputDate - periodStartDate).Days / 14 + 1;
        return payPeriod;
    }
