    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            // You don't need to set primary key. EF take Id and create an identity column
            //HasKey(t => t.Id); 
            // Table & Column Mappings
            ToTable("users");
            // No column mappings in this case.
            // Relationships
            HasRequired(t => t.Group)
                .WithMany(t => t.Users)
                .Map(d => d.MapKey("user_group"));
        }
    }
