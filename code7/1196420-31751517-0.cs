    public static class MenuItemExtensions {
      public static ApplicationUser GetUserCreated(this MenuItem menuItem, DbContext db) {
        db.ApplicationUsers.SingleOrDefault(u => u.Username == menuItem.CreatedBy);
      }
      public static ApplicationUser GetUserModified(this MenuItem menuItem, DbContext db) {
        db.ApplicationUsers.SingleOrDefault(u => u.Username == menuItem.ModifiedBy );
      }
    }
