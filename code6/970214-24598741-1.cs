    public class UserViewModel
    {
        public string[] Select { get; set; }
        public Where[] where { get; set; }
        public Sorted[] sorted { get; set; }
    }
    public class Where
    {
        public bool IsComplex { get; set; }
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Value { get; set; }
        public bool IgnoreCase { get; set; }
    }
    public class Sorted
    {
        public string Name { get; set; }
        public string Direction { get; set; }
    }
