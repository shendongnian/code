    var ordersWithDiscounts = this.Repository.GetOrders()
        .Where(o => 
            o.AllowanceCharge.Any(ac => !ac.ChargeIndicator) &&
            o.IssueDate > DateTime.Now.AddDays(-10) &&
            o.IssueDate < DateTime.Now.AddDays(-1));
    var sumOfOrdersWithDiscounts = ordersWithDiscounts.Sum(o => o.TotalCostOrWhatever);
    var discounts = ordersWithDiscounts
        .SelectMany(o => o.AllowanceCharge.Where(ac => !ac.ChargeIndicator))
        .ToList();
