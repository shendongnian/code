    public static class UserQueries {
      public static IEnumerable<User> GetInRoles(this IRepository repository, params string[] roles) 
      {
        ...
      }
    }
