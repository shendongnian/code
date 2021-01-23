    public class Ship {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Speed { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual Sector Destination { get; set; }
    }
    public class Sector {
        public Int64 X { get; set; }
        public Int64 Y { get; set; }
        public virtual ICollection<Ship> Ships { get; set; }
        public virtual ICollection<Ship> IncomingShips { get; set; }
    }
    
    protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        .....
        modelBuilder.Entity<Sector>()
                    .HasMany(p => p.Ships)
                    .WithRequired(p => p.Sector)
                    .WillCascadeOnDelete(false);
        modelBuilder.Entity<Sector>()
                    .HasMany(p => p.IncomingShips)
                    .WithRequired(p => p.Destination)
                    .WillCascadeOnDelete(false);
    }
