    public class SecurityContext : DbContext
    {
      public SecurityContext(IConnectionSettings settings)
        : base (settings.Name)
      {
      }
    }
