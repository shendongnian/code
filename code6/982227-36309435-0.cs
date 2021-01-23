    public class ApplicationUserMapConfiguration : EntityTypeConfiguration<ApplicationUserMap>
    {
        public ApplicationUserMapConfiguration()
        {
            ToTable("ApplicationUserMap", "Users");
            HasKey(c => c.Id);
         }
    }
