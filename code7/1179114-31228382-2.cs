    using (var db = new MyContext()) {
      var data = db.Users.Join(db.UserRoles, u=>u.UserId, r=>r.UserId, (u,r) => new { u, r})
                   .Join(db.Roles, ur=>ur.r.RoleId, q=>q.RoleId, (ur,q)=>new {ur, q})
                   .Select(m=> new {m.ur.u.UserName, m.ur.u.IsActive, m.q.RoleName})
    }
