    var data = UnitOfWork.Leads.Query()
                         // Do this part of the query in SQL
                         .Where(p => p.SalesPhaseId == naId || 
                                     p.SalesPhaseId == rejectedId) 
                         .AsEnumerable()
                         // Do the rest of the query in-process
                         .Where(p => p.CreatedDate.Date >= fromDate &&
                                     p.CreatedDate.Date <= toDate)
                         .Select(...)
