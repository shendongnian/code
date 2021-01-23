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
    }
