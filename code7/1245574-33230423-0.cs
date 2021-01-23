                           EmployeeId = g.Key.Em,
                           EmployeeNumber = g.FirstOrDefault().Employee.EmployeeNumber,
                           FullName = g.FirstOrDefault().Employee.FullName,
                           HK1 = (decimal)g.FirstOrDefault().ManDays,
                           Basis1 = (decimal)g.FirstOrDefault().BonusBase,
                           HK2 = (
                                  (from d in db.DailyBonus 
                                  where d.Date>= startDate2 && d.Date<=endDate2
                                  group d by new { Em = d.Employee.Id } into g2
                                  select new 
                                  {
                                     Mandays =  g.FirstOrDefault().ManDays <-- this is decimal type
                                  }
                                 ).FirstOrDefault(),
                       };
