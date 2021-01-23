    public class YourModelTypeConfiguration : EntityTypeConfiguration<YourModelType>
    {
        public YourModelTypeConfiguration()
        {
            // ... some other configurations ;
            Property(p => p.Birth).IsOptional();
        }
    }
