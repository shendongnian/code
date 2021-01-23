    public class PlaceMap : ComplexTypeConfiguration<EFPlace>
    {
        public PlaceMap ()
        {
            Property(p => p.EFLocation).HasColumnName("Location");
            Ignore(p => p.Location);
        }
    }
