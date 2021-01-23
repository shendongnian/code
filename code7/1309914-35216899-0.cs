    List<AspNetUser> approverprofiles = db.AspNetUsers.Where(w => w.Subsidary_ID =="04").ToList();
    
    List<AspNetRole> approverusers = db.AspNetRoles.Where(w => w.Name == "Approver").ToList();
    
    approverprofiles.AddRange(approverusers);
