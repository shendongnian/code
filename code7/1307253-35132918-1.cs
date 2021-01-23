    public class MovementMap : EntityTypeConfiguration<Movement>
    {
        public MovementMap()
        {
            ToTable("viewMovement", "met");
            HasKey(e => e.IdMovement);
            Property(r => r.DateMovement).HasColumnName("dateMovement").HasColumnType("Date"); 
        }
    }
