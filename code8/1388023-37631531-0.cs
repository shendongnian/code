    nameQuery = (from user in db.Users
      where user.Roles.Any(r => r.RoleId == roleId)
      where !db.Appeal.Any(y => y.PatientId == user.Id) // if no record found in appeal
      || 
      db.Appeal.OrderByDescending(x => x.Time).FirstOrDefault(p => p.PatientId 
      == user.Id).IsApprove == 2
      // or got appeal, but the latest result is rejected
    
      select new Patient {
       PatientId = user.Id,
       PatientName = user.FullName,
       UniqueId = user.UniqueId
       }).OrderBy(x => x.PatientId);
