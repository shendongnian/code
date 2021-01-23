    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OwnerId { get; set; }
        public virtual User Owner { get; set; }
        public int? LockedByUserId { get; set; }
        public virtual User LockedByUser { get; set; }
        [Timestamp]
        public byte[] ETag { get; set; }
    }
