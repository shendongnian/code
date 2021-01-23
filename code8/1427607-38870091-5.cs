    public class FirstRecord {
        public int Id { get; set; }
        public int Name { get; set; }
        // Disable lazy load
        [Aggregate]
        public SecondRecord SecondRecord { get; set; }
        // Lazy load
        public ThirdRecord ThirdRecord { get; set; }
    }
    public class SecondRecord {
        public int Id { get; set; }
        public int Name { get; set; }
    }
    public class ThirdRecord {
        public int Id { get; set; }
        public int Name { get; set; }
    }
