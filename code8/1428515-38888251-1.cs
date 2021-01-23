    var noofRecords = (from c in db.ts_upld_doc
                       where c.docStatus == "notVerified"
                       group c by new { c.clientID, c.clientName }  into grouping
                       select new
                       {
                            ClientId = grouping.Key.clientID,
                            ClientName = grouping.Key.clientName,
                            Count = grouping.Count()
                       }).ToList();
