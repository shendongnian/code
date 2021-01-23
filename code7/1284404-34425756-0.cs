    public class Bar
    {
        public int Id { get; set; }
        public string BarDesc { get; set; }
        public virtual List<Foo> Foos { get; set; } = new List<Foo>();
    }
