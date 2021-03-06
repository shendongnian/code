    var data = from d in db.DailyBonus
                           where d.Date>= startDate1 && d.Date<=endDate1
                           group d by new { Em = d.Employee.Id } into g
                           select new BasisViewModel
                           {
                               EmployeeId = g.Key.Em,
                               EmployeeNumber = g.FirstOrDefault().Employee.EmployeeNumber,
                               FullName = g.FirstOrDefault().Employee.FullName,
                               HK1 = (decimal)g.FirstOrDefault().ManDays,
                               Basis1 = (decimal)g.FirstOrDefault().BonusBase,
                               HK2 = (
                                      (from d in db.DailyBonus 
                                      where d.Date>= startDate2 && d.Date<=endDate2
                                      group d by new { Em = d.Employee.Id } into g2
                                      select g.FirstOrDefault().ManDays <-- this is simple value now
                                     ).FirstOrDefault(),<--this is another first or default 
                           };
