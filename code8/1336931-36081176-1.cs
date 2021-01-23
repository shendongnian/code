    var startDate = new DateTime (2016, 1, 1);
    var endDate = new DateTime (2016, 1, 4);
    Set.SelectMany(u => u.Orders).
        Where (order => startDate <= order.Date && order.Date <= endDate) // If filter needed
        GroupBy (order => order.Date, (date, values) =>
            new OrderDateSummary () {
                Date = date,
                Total = values.Count ()
            }).
        OrderBy (summary => summary.Date).
        ToList ();
