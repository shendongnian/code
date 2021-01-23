    public class UserSitesContext : DbContext
    {
        public UserSitesContext()
            :base("name=UserSitesContext")
        {
        }
        public virtual DbSet<Site> Sites { get; set; }
    }
