    bool eTypeIsAll = eType == EntityType.All;
    bool aTypeIsAll = aType == AuditActionType.All;
    AuditTrail = 
        ent.tblAuditTable
           .Where(s => s.KeyFieldID == ID 
                       && (
                           eTypeIsAll ? (
                                (
                                    !aTypeIsAll ? 
                                        s.AuditActionTypeENUM == aType
                                        : true
                                )
                                && s.EmployeeCode.Contains(code) 
                                && s.UserName.Contains(username)
                           )
                           : (
                                (
                                    !aTypeIsAll ? 
                                        s.AuditActionTypeENUM == aType
                                        : true
                                )
                                && s.EmployeeCode.Contains(code) 
                                && s.UserName.Contains(username)
                                && s.DataModel == eType
                                
                           )
                           
                       ))
            .OrderByDescending(s => s.DateTimeStamp)
            .ToList();
