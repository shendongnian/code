    using (DbContext db = new DbContext())
    {
        db.Connection.Open();
        Employee currentApplicationUser = db.Users.FirstOrDefault(u => u.UserName.Equals(userName));
        currentApplicationUserEmployee = db.Employees.SingleOrDefault(e => e.ApplicationUser == currentApplicationUser);
       
        db.Connection.Close();
        return currentApplicationUserEmployee 
    }
