    IEnumerable<DateTime> GetPeriodicDeliveryDates(DateTime today, object dayOfDelivery, int period)
    {
        return GetPeriodicDeliveryDates(today, (DayOfWeek)dayOfDelivery, period);
    }
    IEnumerable<DateTime> GetPeriodicDeliveryDates(DateTime today, DayOfWeek dayOfDelivery, int period)
    {
        // Get the date of the first delivery. 
        var firstDelivery = FirstDayOfWeekAfter(today, dayOfDelivery);
        while (true)
        {
            // Infinitely yield dates separated by the supplied period length.
            yield return firstDelivery;
            firstDelivery = firstDelivery.AddDays(period);
        }
    }
    
