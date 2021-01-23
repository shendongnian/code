    public class LibraryManagementWebAppContext : IdentityDbContext<ApplicationUser>
    {
       public LibraryManagementWebAppContext() : base("name=DefaultConnection")
        {
        }
        public DbSet<UniversityLibrary> UniversityLibraries { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
     
            modelBuilder.Entity<IdentityUserLogin>().HasKey(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            modelBuilder.Entity<UniversityLibrary>().HasKey(r => r.UniversityLibraryId);
            base.OnModelCreating(modelBuilder);
        }
        
    }
