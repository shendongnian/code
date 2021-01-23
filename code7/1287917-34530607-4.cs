    public class CarEntityTypeConfiguration : EntityTypeConfiguration<Car>
    {
        public CarEntityTypeConfiguration()
        {
            HasKey(t => new { t.ID, t.ChassisSerial });
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
    
            HasOptional(t => t.Person).WithMany().HasForeignKey(t => new { t.PersonID, t.PersonSsn });
        }
    }
