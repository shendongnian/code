    public class Booking
        {
            public Booking(int id, float amount)
            {
                BookingId = id;
                BookingAmount = amount;
            }
    
            public int BookingId { get; }
            public float BookingAmount { get; }
        }
    
        public class BookingComparer : IEqualityComparer<Booking>
        {
            public bool Equals(Booking x, Booking y)
            {
                return (x.BookingAmount == y.BookingAmount) && (x.BookingId == y.BookingId);
            }
    
            public int GetHashCode(Booking obj)
            {
                return obj.BookingId.GetHashCode()*17 + obj.BookingAmount.GetHashCode()*17;
            }
        }
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                var booking1 = new Booking(1, 12);
                var booking2 = new Booking(1, 12);
    
                var bookings = new List<Booking>();
                bookings.Add(booking1);
                bookings.Add(booking2);
    
                var result = bookings.Distinct(new BookingComparer()).ToList();
            }
        }
