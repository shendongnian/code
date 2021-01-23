    // This may not be required, depending on the source.
    fromDate = fromDate.Date;
    // This will be, although you may be able to get rid of the ".Date" part.
    toDate = toDate.Date.AddDays(1);
    var data = UnitOfWork.Leads.Query()
                         // Do this part of the query in SQL
                         .Where(p => (p.SalesPhaseId == naId || 
                                      p.SalesPhaseId == rejectedId) &&
                                     p.CreatedDate >= fromDate &&
                                     p.CreatedDate < toDate)
                         .Select(...)
