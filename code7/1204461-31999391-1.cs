    var query = db.BalanceHistories
        .Where(h=>temp.Contains(h.LoanType ?? 0));
    if (officer!=null)
    {
       // Depending on your database, the ToLower()s here may not be needed.
       query=query.Where(h=>h.OfficerName.ToLower() == officer.ToLower()))
    }
    var res=(from h in query
             group h by new { h.Date.Value.Month, h.Date.Value.Year } into p
             select new
                           {
                               Month = p.Key.Month,
                               Year = p.Key.Year, 
                               Count = p.Count(),
                               Balance = p.Sum(x => x.Balance),
                               Delinquent = p.Sum(x => x.Delinquent)
                           });
