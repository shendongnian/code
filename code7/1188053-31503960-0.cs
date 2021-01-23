    public class Hit
    {
        public int Id { get; set; }
        public virtual Lead Lead { get; set; }
        public virtual Account Account { get; set; }
    }
