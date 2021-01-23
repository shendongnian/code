    public class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);
        }
    }
