    public class Thing
    {
        public Thing()
        {
            Things = new List<Thing>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<Thing> Things { get; set; }
    }
