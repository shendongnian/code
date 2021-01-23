    public partial class DatabaseContext : DbContext
        {
            
            public DatabaseContext(string connString)
                : base(connString)
            {
                Database.SetInitializer<DatabaseContext>(null);
            }
    
            public DbSet<ASPStateTempApplication> ASPStateTempApplications { get; set; }
            public DbSet<ASPStateTempSession> ASPStateTempSessions { get; set; }
            public DbSet<sysdiagram> sysdiagrams { get; set; }
            public DbSet<UserProfile> UserProfiles { get; set; }
            public DbSet<VisualizacoesLog> VisualizacoesLogs { get; set; }
            public DbSet<webpages_Membership> webpages_Membership { get; set; }
            public DbSet<webpages_OAuthMembership> webpages_OAuthMembership { get; set; }
            public DbSet<webpages_Roles> webpages_Roles { get; set; }
          
    	//Another Tables from database
    
    
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new ASPStateTempApplicationMap());
                modelBuilder.Configurations.Add(new ASPStateTempSessionMap());    
                modelBuilder.Configurations.Add(new sysdiagramMap());
                modelBuilder.Configurations.Add(new UserProfileMap());
                modelBuilder.Configurations.Add(new VisualizacoesLogMap());
                modelBuilder.Configurations.Add(new webpages_MembershipMap());
                modelBuilder.Configurations.Add(new webpages_OAuthMembershipMap());
                modelBuilder.Configurations.Add(new webpages_RolesMap());
                
                //Another mappings from database
    
    
                
            }
    }
