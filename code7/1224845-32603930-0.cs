     public sealed class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            ToTable("RepricerUsers", "miportal");
        }
    }  
 
 
