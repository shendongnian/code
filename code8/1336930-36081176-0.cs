    Set.SelectMany(u => u.Orders).
        GroupBy (order => order.Date, (date, values) =>
            new OrderDateSummary () {
                Date = date,
                Total = values.Count ()
            }).
        OrderBy (summary => summary.Date);
