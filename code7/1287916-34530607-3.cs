    public class PersonEntityTypeConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonEntityTypeConfiguration()
        {
            HasKey(t => new { t.ID, t.Ssn });
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
