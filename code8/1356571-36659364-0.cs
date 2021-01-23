                DateTime sinceLast = DateTime.Now.AddDays(-n);
                DateTime sinceLastAtMidnight = new DateTime(sinceLast.Year, sinceLast.Month, sinceLast.Day);
    
                var result =  lstDate.Where(x => x >= sinceLastAtMidnight)
                                     .Select(x => new
                                        { DateActual = x,
                                          DateWitoutTime = new DateTime(x.Year, x.Month, x.Day) 
                                        }) 
                                     .GroupBy(x => x.DateWitoutTime)
                                     .Select(x => x.OrderByDescending(y => y.DateActual).FirstOrDefault())
                                     .Select(x => x.DateActual)
                                     .ToList();
