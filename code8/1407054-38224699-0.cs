    public Dictionary<int, decimal> RevenuePerDayOfWeek(DateTime startDate, DateTime endDate)
    {
        db = new FruitStoreDataContext();
    
        var sumPerday = (from s in db.OrderDetails
                         where s.Order.OrderDate >= startDate && s.Order.OrderDate <= endDate
                         group s by s.Order.OrderDate.DayOfWeek into grp
                         select new
                         {
                             Day = grp.Key,
                             Sum = grp.Sum(a => a.Price * a.Quantity)
                         }).ToDictionary(x => x.Day, x => x.Sum);
    
        return sumPerday;
    }
