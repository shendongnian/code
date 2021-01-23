    class Program
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        static void Main(string[] args)
        {
            Program p = new Program();
        }
    class Program
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        static void Main(string[] args)
        {
            Program p = new Program();
        }
        public Program()
        {
            var _BookingService = new List<Booking>()
            {
                new Booking() { ID = 100, RoomID = 1, DateFrom = DateTime.Now.AddDays(-1), DateTo = DateTime.Now.AddDays(1) }
            };
            this.DateTo = DateTime.Now;
            this.DateFrom = DateTime.Now;
            var roomsBooked = from b in _BookingService
                                 where (this.DateFrom >= b.DateFrom) && (this.DateFrom <= b.DateTo) ||
                                         (this.DateTo >= b.DateFrom) && (this.DateTo <= b.DateTo)
                                 select b;
            IEnumerable<Room> availableRooms = null;
            //if there are currently rooms booked
            if (roomsBooked.Count() > 0)
                availableRooms = GetRooms().Where(r => roomsBooked.Any(b => b.RoomID != r.ID));
            else
                availableRooms = GetRooms();
            
            foreach (var room in availableRooms)
                Console.WriteLine($"{room.Title}");
            Console.ReadKey();
        }
        public List<Room> GetRooms()
        {
            return new List<Room>()
            {
                new Room() { ID = 1, Title = "Room 1" },
                new Room() { ID = 2, Title = "Room 3" }
            };
        }
    }
    public class Room
    {
        public int ID { get; set; }
        public string Title { get; set; }
        
    }
    public class Booking
    {
        public int ID { get; set; }
        public int RoomID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
