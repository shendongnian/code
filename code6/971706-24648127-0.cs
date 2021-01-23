    public static IEnumerable<ApplicationUser> GetListByRole(params string[] roles)
    {
        using (AppDbContext db = new AppDbContext())
        {
            return db.Users
                    .Where(u => roles.Contains(u.Role.Name) && 
                           u.DateDeleted == null)
                    .ToList<ApplicationUser>();
        }
    }
