    public partial class ThetherDBContext : DbContext
    {
        public ThetherDBContext()
            : base("name=ThetherDBContext")
        {
        }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<TypeOfSeat> TypesOfSeats { get; set; }
        public virtual DbSet<Seat> Seats { get; set; } ... etc.
