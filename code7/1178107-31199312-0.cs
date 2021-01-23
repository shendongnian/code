    var roles = (from d in db.TB_UserRoles
                  where d.UserID == userID
                  select d.RoleID).ToList();
    
    
    var menu = (from d in db.TB_MenuRoles
                where roles.Contains(d.RoleID)
                select new Menu
                {
                 MenuName = d.TB_Menu.Name,
                 RoleType = d.RoleID
                }).Distinct().OrderBy(x=>x.RoleType).ToList();
