    const int BillingDay = 4; //The day the bill gets generated every month
    DateTime today = DateTime.Today; //Today's date
    int numDaysLeft; 
    if(today.Day <= BillingDay)
    {
        numDaysLeft = (new DateTime(today.Year, today.Month, BillingDay) - today).Days;
    }
    else
    {
        var oneMonthFromToday = today.AddMonths(1);
        var billingDateNextMonth = 
            new DateTime(oneMonthFromToday.Year, oneMonthFromToday.Month, BillingDay);
        numDaysLeft = (billingDateNextMonth - today).Days;
    }
