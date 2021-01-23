    public abstract class UserMapBase<TUser> : EntityTypeConfiguration<TUser>
        where TUser : User
    {
        protected UserMapBase()
        {
            // Table Mapping
            ToTable("Users");
            this.Property(x => x.Username).HasColumnName("Username");
    
    
            // Other mapping goes here
        }
    }
