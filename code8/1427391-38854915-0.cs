            var model = ((from p in db.WorkPointRoles
                         where p.WorkPoint == wp
                         select p).AsEnumerable()
           .Select(r => new RegisterEmployee_Step6Model()
           {
               Role = r.Role,
               isSelected = false,
               RoleDescription = cg.GetRoleDescription(r.Role),
               IconLocation = cg.GetRoleIconLocation(r.Role)
           })).ToList();
