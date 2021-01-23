    public class ConnectionPointRoute
    {
        public int ConnectionPointId { get; set; }
        public int RouteId { get; set; }
        public int Position { get; set; }
        public virtual ConnectionPoint ConnectionPoint { get; set; }
        public virtual Route Route { get; set; }
    }
