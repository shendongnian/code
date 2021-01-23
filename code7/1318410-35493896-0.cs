    using (DataContext db = new DataContext())
    {
        var users = db.Users
            .Include("Roles.Role")
            .Select(user => new MyDtoClass() {
                 // TODO you set here you DTO properties eg. FirstName, LastName, Role Name etc... and not your complete entity object.
            });
    }
