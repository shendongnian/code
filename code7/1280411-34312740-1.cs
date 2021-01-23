        CustomerTransactions.Where(c => c.TransTypeID==12 && !(c.Marathi == 0 && c.Tamil == 0))
                             .OrderBy(c => c.Student)
                             .Select(c => new {
                                 Student=c.Student,
                                 English=c.English,
                                 Hindi=c.Hindi,
                                 Tamil=c.Tamil,
                                 Marathi=c.Marathi
                             }).ToList();
