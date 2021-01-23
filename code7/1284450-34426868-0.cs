    public class Seat
    {
        public int SeatNo { get; set; }
        public bool FirstClass { get; set ; }
        public bool Booked { get; set; } // could actually be an instance of a booking info class including name and ticket id, etc.
    }
    
    public class Flight
    {
        public List<Seat> Seats = new List<Seat>();
        private int _lastSeat = 0;
        public void AddSeats(int num, bool firstClass)
        {
            for (int i = 0; i < num; i++)
            {
                _lastSeat++;
                Seats.Add(new Seat { SeatNo = num, FirstClass = firstClass });
            }
        }
        public int BookNextAvailableSeat(bool firstClass)
        {
            foreach (Seat seat in Seats.AsQueryable().Where(x => x.FirstClass == firstClass)
            {
                if (!seat.Booked)
                {
                    seat.Booked = true;
                    return seat.SeatNo;
                }
            }
            return null;
        }
    }
