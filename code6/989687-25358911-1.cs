    var detailsOnly = (from det in db.details
                       join inc in db.Incidents on det.detOtherId equals inc.incidentid into incidentsLo
                        from subInc in incidentsLo.DefaultIfEmpty()
                       join cli in db.Accounts on subInc.accountid equals cli.accountid into accountsLo
                        from subCli in accountsLo.DefaultIfEmpty()
    
                       select new MyDetail(det)
                       {
                           AccName = subAcc.name, 
                           AccRef = subAcc.accountnumber,
                           IncidentTicketNumber = subInc.ticketnumber,
                           IncidentKeyDescription = subInc.title,
                           IncidentMainContact = subInc.maincontactname
                        }).ToArray();
    
    var groupedDetails = detailsOnly.GroupBy(c => c.det.detOtherId);
    var query = db.headers.Where(head => head.IsDone == isdone
                                         && head.type == typeId
                                         && head.accountid == AccountId);
    var result = query.Join(groupedDetails, c => c.headOtherId, c => c.Key, (a, b) => new MyHeader(a) { MyDetails = b })).ToList();
