    var baseQuery = ent.tblAuditTable.Where(s => s.KeyFieldID == ID && s.EmployeeCode.Contains(code) && s.UserName.Contains(username));
    var realQuery = baseQuery;
    if (eType != EntityType.All){
      realQuery = realQuery.Where(s=>s.EmployeeCode.Contains(code));
    }
    if (aType != EntityType.All){
      realQuery = realQuery.Where(x=>s.AuditActionTypeENUM == aType);
    }
    var result = realQuery.OrderByDescending(s => s.DateTimeStamp).ToList()
    
    AuditTrail = result;
