        public class ClassNameConfiguration : EntityTypeConfiguration<ClassName>
        {
            public ClassNameConfiguration()
            {
                Property(x => x.Title).IsRequired();
            }
        }
