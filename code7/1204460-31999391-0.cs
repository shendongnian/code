    var  query = (from h in db.BalanceHistories
                           where temp.Contains(h.LoanType ?? 0)
                           select h)
    if (officer!=null)
    {
       query=query.Where(q=>h.OfficerName.ToLower() == officer.ToLower()))
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
