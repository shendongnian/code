    public class A
    {
        public int Id { get; set; }
        public int? Item1 { get; set; }
        public int? Item2 { get; set; }
        public virtual B B { get; set; }
    }
    public partial class B
    {
        public int Id { get; set; }
        public int? Item1 { get; set; }
        public int? Item2 { get; set; }
        public virtual IList<A> A { get; set; } = new List<A>();
    }
