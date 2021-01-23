    public class Garment
    {
        public int Id { get; set; }
        public string Slug { get; set; }
        public Kit Kit { get; set; }
        public Font Font { get; set; }
        public IList<Path> Paths { get; set; }
    }
