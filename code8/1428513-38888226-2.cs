    var noofRecords = (from c in db.ts_upld_doc
                       where c.docStatus == "notVerified"
                       group c by new { c.clientId , c.clientName } into grouping
                       select new
                       {
                          ClientId  = grouping.Key.clientId,
                          ClientName = grouping.Key.clientName,
                          Count = grouping.Count()
                       });
    
    return noofRecords.ToList();
