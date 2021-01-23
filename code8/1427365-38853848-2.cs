    int billingDay = 4;
    DaysUntilBilling(billingDay, DateTime.Now); //26 (today is 9th Aug 2016)
    DaysUntilBilling(billingDay, new DateTime(2016, 09, 03); //1
    DaysUntilBilling(billingDay, new DateTime(2016, 09, 04); //0
    DaysUntilBilling(billingDay, new DateTime(2016, 08, 05); //30
    DaysUntilBilling(billingDay, new DateTime(2016, 12, 19); //16
