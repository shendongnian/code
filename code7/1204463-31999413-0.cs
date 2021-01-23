    var  res = (from h in db.BalanceHistories
                       where temp.Contains(h.LoanType ?? 0)
                       && ((officer == null) || (h.OfficerName.ToLower() == officer.ToLower()))
                       group h by new { h.Date.Value.Month, h.Date.Value.Year } into p
                       select new
                       {
                           Month = p.Key.Month,
                           Year = p.Key.Year, 
                           Count = p.Count(),
                           Balance = p.Sum(x => x.Balance),
                           Delinquent = p.Sum(x => x.Delinquent)
                       }).ToList();
