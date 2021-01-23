    public class Seat
    {
        public Guid Id { get; set; }
        public string RowNumber { get; set; }
        public int SeatNumber { get; set; }
        
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
    public class Reservation
    {
        public Guid Id { get; set; }
        public virtual ICollection<Seat> Seats { get; set; }
    }
    public static List<Seat> GetSeatsForReservation(Guid reservationId)
    {
      List<Seat> result = null;
     using (var db = new EntityContext())
      {
         result = db.Seats.Where(
                s => s.Reservations.Id == reservationId).ToList();
        }
       return result ;
     }`
