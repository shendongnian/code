    var userList = (from entry in this.UserManager.Users
                   group entry by entry.Id into g
                   select new { g.Id, g.UserName, g.Email, g.EmailConfirmed, g.PhoneNumber, 
                   g.PhoneNumberConfirmed, Roles=g.Roles.Where(r=>r.RoleId != "4").ToList() })
                  .Where(g=>g.Roles.Count>0);
