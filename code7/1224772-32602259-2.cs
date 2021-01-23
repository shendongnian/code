    var data = ctx.ShiftSchedule.Where(x => x.Company == company 
                                            && x.EmployeeId == item.EmployeeId)
                                .GroupBy(x => new { x.CODE, x.SCODE })
                                .Select(x => new 
                                            {
                                                CODE = x.Key.CODE,
                                                SCODE = x.Key.SCODE,
                                                SDATE  = x.Max(z => z.SDATE) 
                                            })
                                .OrderByDescending(x => x.SDATE).FirstOrDefault();
