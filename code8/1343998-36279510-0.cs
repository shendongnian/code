    public async Task<ActionResult> Roles()
        {
            var user= context.Users.Include(u => u.Roles).Where(u=>u.Roles.Any(r=>r.Name=="RoleName")).ToList();
            return View(user);
        }
