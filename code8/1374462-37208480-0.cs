    public static List<Seat> GetSeatsForReservation(Guid reservationId)
        {
            var db= new  EntityContext();
            return (from s in db.ReservationSeat
                    where s.ReservationID==Guid
                    select s.seat).ToList();
        }
   
