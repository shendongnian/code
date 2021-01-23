    public class B
    {
        public string Name { get; set; }
        public string ForeignId { get; set; }
        public int Value { get; set; }
    }
    public class A
    {
        public B TestB1 { get; set; }
        public B[] TestB2 { get; set; }
    }
