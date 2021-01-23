    public class ReadingOrder
    {
        public virtual int Id { get; set; }
        public virtual Order Order { get; set; }
        public virtual int OrderId { get; set; }    // Explicit and direct foreign Key
    }
