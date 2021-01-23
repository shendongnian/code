    public class Trip
    {
        public string Port { get; set; }
        public string TripId { get; set; }
        public string StatusId { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IList<Trip> tripList = new List<Trip>();
            tripList.Add(new Trip() { TripId = "123", Port = "1" });
            tripList.Add(new Trip() { TripId = "124", Port = "2" });
            tripList.Add(new Trip() { TripId = "124", Port = "3" });
            tripList.Add(new Trip() { TripId = "126", Port = "4" });
            tripList.Add(new Trip() { TripId = "126", Port = "4" });
            var doubleTrip = tripList
                .GroupBy(c => new { c.TripId, c.Port })
                .Where(grp => grp.Count() > 1)
                .Select(grp => new { Port = grp.Key.Port, TripId = grp.Key.TripId });
            foreach (var d in doubleTrip)
            {
                Console.WriteLine("TripId: {0}, Port: {1}", d.TripId, d.Port);
            }
            Console.ReadLine();
        }
