    private int GetNumDaysToNextBillingDate(int billingDayOfMonth)
    {
        DateTime today = DateTime.Today;
        if (today.Day <= billingDayOfMonth)
        {
            return (new DateTime(today.Year, today.Month, billingDayOfMonth) - today).Days;
        }
        else
        {
            var oneMonthFromToday = today.AddMonths(1);
            var billingDateNextMonth = 
                new DateTime(oneMonthFromToday.Year, 
                oneMonthFromToday.Month, billingDayOfMonth);
            return (billingDateNextMonth - today).Days;
        }
    }
