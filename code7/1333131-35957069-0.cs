    return 
        from item in orderMonthlyEntities
        group item by item.StoreName into storeNameGroup
        orderby storeNameGroup.Key
        select new MonthlyOrdersByStoreResponse
        {
            StoreName = storeNameGroup.Key,
            Values = 
                (from item in storeNameGroup
                 group item by new { item.Year, item.Month } into monthGroup
                 orderby monthGroup.Key.Year, monthGroup.Key.Month
                 select new OrderDeliveryCountByMonth
                 {
                     Year = monthGroup.Key.Year,
                     Month = new DateTime(monthGroup.Key.Year, monthGroup.Key.Month, 1).ToMonthName(),
                     OrderCount = monthGroup.Sum(item => item.OrderCount)
                 }).ToList()
        };
