    this.Repository.GetOrders()
        .Where(o => o.IssueDate > DateTime.Now.AddDays(-10) &&
                    o.IssueDate < DateTime.Now.AddDays(-1))
        .SelectMany(o => o.AllowanceCharge
            .Where(ac => !ac.ChargeIndicator)
            .Select(ac => new { order = o, charge = ac}))
        .GroupBy(_ => _.charge.Id)
        .Select(grp => new
        {
            AllowanceChargeId = grp.Key,
            OrdersForThisCharge = grp.Select(_ => _.order)
        });
