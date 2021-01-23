    [Table("Seat")]
    public partial class Seat
    {
        public Seat()
        {
            ReservedSeats = new HashSet<ReservedSeat>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int seatId { get; set; }
	
	... etc.
