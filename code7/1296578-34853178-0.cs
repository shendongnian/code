     var query2 = (from a in _entities.ISTReasons
                          join b in _entities.ISTMotivations on new { col1 = a.ISTReasonID, col2 = Id } equals new { col1 = b.ISTReasonID, col2 = b.ISTID }
                          into tmp1
                          from c in tmp1.DefaultIfEmpty()
                          select new
                          {
                              ISTReasonID = a.ISTReasonID,                        
                              ReasonDesc = a.LookupDesc,
                              ReasonCode = a.LookupCode,
                              Checked = c.ISTMotivationID != null ? "Y" : "N"
                          });
