    db.VisualReposts.Join(db.VisualRepostRoleLists, 
                          vr => vr.VisualReportSK,
                          vrl => vrl.VisualReportSK 
                          (vr, vrl) => new { vr, vrl}).Join(db.Roles, 
                                                           vrj => vrj.vrl.RoleSK,
                                                           r => r.RoleID,
                                                      vrj, r => new {vr = vrj.vr, 
                                                                    vrl = vrj.vrl, 
                                                                    role = r} )
      //follow the same patter for the rest of the joins.  
      // Also add your where clause, it might be a better idea to start 
      //from the users table so you can filter first
