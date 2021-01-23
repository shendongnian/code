    var result = db.tblUsers
       .Select(u => new
       {
           UserId = u.ID,
           Login = u.UserLogin,
           FullName = u.Name + " " +  u.Surname,
           ItemsToSell = db.tblSales.Count(s => s.tblUserId == u.ID)
        })
        .Where(x => x.ItemsToSel > 0)
        .OrderByDescending(x => x.ItemsToSell)
        .ToList();
